def PROJECT_NAME = "Tic-Tac-Toe"
def CUSTOM_WORKSPACE = "D:\\UnityProjects\\${PROJECT_NAME}"
def UNITY_VERSION = "2022.3.54f1"
def UNITY_INSTALLATION = "C:\\Program Files\\Unity\\Hub\\Editor\\${UNITY_VERSION}\\Editor"

pipeline{
    environment{
        PROJECT_PATH = "${CUSTOM_WORKSPACE}"
        NEXUS_IP_ADDRESS = "http://192.168.2.38:8081" //Your full Nexus IP address+port. Example: http://192.168.1.200:8081
        NEXUS_USERNAME = "riddhi" //Your Nexus username
        NEXUS_PASSWORD = credentials('NEXUS_PASSWORD')
        NEXUS_REPOSITORY = "unity-jenkin-builds"
        /*
        MAC_PASSWORD = credentials('MAC_PASSWORD')

        GOOGLE_PLAY_API_JSON_LOCATION = credentials('GOOGLE_PLAY_API_JSON_LOCATION')
        TEST_PROJECT_KEYSTORE_FILE = credentials('TEST_PROJECT_KEYSTORE_FILE')
        KEYSTORE_PASS = credentials('KEYSTORE_PASS')
        ALIAS_NAME = credentials('ALIAS_NAME')
        ALIAS_PASS = credentials('ALIAS_PASS')
        BUNDLE_ID = "" //Your bundle ID. Ex: com.defaultcompany.test
        MAC_IP_ADDRESS = "" //Your mac IP address
        MAC_USERNAME = "" //Your mac username
        */
    }

    agent any
     
    stages{
        stage('Git Version Check') {
            when { expression {TEST == 'true' } } // Ensure 'TEST' is properly referenced
            steps {
                script {
                    bat '''
                    echo "Hello World!"
                    '''
                }
            }
        }

        stage('Build Windows'){
            when{expression {BUILD_WINDOWS == 'true'}}
            steps{
                script{
                    withEnv(["UNITY_PATH=${UNITY_INSTALLATION}"]){
                        bat '''
                        "%UNITY_PATH%\\Unity.exe" -quit -batchmode -projectPath %PROJECT_PATH% -executeMethod BuildScript.BuildWindows -logFile -
                        '''
                    }
                }
            }
        }

     stage('Deploy Windows'){
            when{expression {DEPLOY_WINDOWS == 'true'}}
            steps{
                script{
                    def buildDate = new Date().format("yyyyMMdd_HHmm")
                    env.ARTIFACT_NAME = "Windows_Build_${buildDate}.zip"

                    bat '''
                    curl -u %NEXUS_USERNAME%:%NEXUS_PASSWORD% --upload-file %PROJECT_PATH%/Builds/Windows.zip %NEXUS_IP_ADDRESS%/repository/%NEXUS_REPOSITORY%/%ARTIFACT_NAME%
                    '''
                }
            }
        }

        stage('Build WebGL'){
            when{expression {BUILD_WEBGL == 'true'}}
            steps{
                script{
                    withEnv(["UNITY_PATH=${UNITY_INSTALLATION}"]){
                        bat '''
                        "%UNITY_PATH%\\Unity.exe" -quit -batchmode -projectPath %PROJECT_PATH% -executeMethod BuildScript.BuildWebGL -logFile -
                        '''
                    }
                }
            }
        }

        stage('Build Android APK')
        {
            when{expression {BUILD_ANDROID_APK == 'true'}}
            steps{
                script{
                    withEnv(["UNITY_PATH=${UNITY_INSTALLATION}"]){
                        bat '''
                        "%UNITY_PATH%\\Unity.exe" -quit -batchmode -projectPath %PROJECT_PATH% -executeMethod BuildScript.BuildAndroid -buildType APK -logFile -
                        '''
                    }
                }
            }
        }
    }
}

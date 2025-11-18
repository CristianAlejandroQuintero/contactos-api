pipeline {
    agent any

    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = "1"
        DOCKER_IMAGE = "contactos-api"
        DOCKER_TAG = "latest"
    }

    stages {

        stage('Checkout') {
            steps {
                git url: 'https://github.com/CristianAlejandroQuintero/contactos-api.git', branch: 'main'
            }
        }

        stage('Restore') {
            steps {
                powershell 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                powershell 'dotnet build --configuration Release'
            }
        }

        stage('Test') {
            steps {
                powershell 'dotnet test --configuration Release --no-build'
            }
        }

        stage('Publish') {
            steps {
                powershell 'dotnet publish -c Release -o out'
            }
        }

        stage('Docker Build') {
            steps {
                powershell '''
                docker build -t "$env:DOCKER_IMAGE:$env:DOCKER_TAG" .
                '''
            }
        }

        stage('Docker Run (Smoke Test)') {
            steps {
                powershell '''
                docker run -d --name test_container -p 8080:80 "$env:DOCKER_IMAGE:$env:DOCKER_TAG"
                Start-Sleep -Seconds 5
                docker logs test_container
                '''
            }
            post {
                always {
                    powershell 'docker rm -f test_container'
                }
            }
        }

        stage('Deploy') {
            when {
                expression { return env.BRANCH_NAME == 'main' }
            }
            steps {
                echo "Aquí iría un despliegue, docker push, o copiar archivos a un servidor Windows o Linux."
            }
        }
    }

    post {
        success {
            echo '✔ Pipeline completado exitosamente'
        }
        failure {
            echo '❌ El pipeline falló'
        }
    }
}
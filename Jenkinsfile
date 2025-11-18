pipeline {
    agent any

    stages {
        stage('Clonar repositorio') {
            steps {
                git 'https://github.com/CristianAlejandroQuintero/contactos-api.git'
            }
        }

        stage('Construir imagen Docker') {
            steps {
                sh 'docker compose build'
            }
        }

        stage('Levantar contenedores') {
            steps {
                sh 'docker compose up -d'
            }
        }

        stage('Probar API') {
            steps {
                sh 'curl --fail http://localhost:5000/swagger || exit 1'
            }
        }
    }
}

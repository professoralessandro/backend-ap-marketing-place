pipeline {

  agent any
    
  stages {

   stage('Cloning Git') {
      steps {
        git branch: '$Branch', url: 'https://github.com/professoralessandro/backend-ap-marketing-place'
      }
    }

    stage('Replacing Artefacts') {
      steps {
        bat 'xcopy /S /E /Y "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//PROD-artefacts-marketing-place//Environments//backend-mkt-dev"  "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//PROD-backend-marketing-place//basecs" '
      }
    }
	  
    stage('Replacing Script entrypoint') {
      steps {
        bat 'xcopy /S /E /Y "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//Environments//backend-mkt-dev"  "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//PROD-backend-marketing-place//basecs" '
      }
    }
    
    stage('Testing Project') {
      steps {
        bat 'dotnet test "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//PROD-backend-marketing-place//basecs.tests//basecs.tests.csproj" '
      }
    }
    
    stage('Replace Database Scripts') {
      steps {
        bat 'xcopy /S /E /Y "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//PROD-database-marketing-place//BACKUPDATABASEOBJECTS"  "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//PROD-backend-marketing-place//basecs" '
      }
    }
	
    stage('Stoping Docker Compose') {
      steps {
        bat 'cd basecs && docker-compose down'
      }
    }
    
    stage('Deploy Project Docker and Starting Docker Compose') {
      steps {
        bat 'cd basecs && docker-compose  up -d --build'
      }
    }
    
  }
}

pipeline {

  agent any
    
  stages {
	  
    stage('Echo') {
      steps {
        echo 'xcopy /S /E /Y "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//Environments//backend-mkt-dev" '
      }
    }

    // stage('Replacing Artefacts') {
    //   steps {
    //     sh 'cp -r "/c/var/jenkins_home/workspace/Environments/backend-mkt-dev"  "/c/var/jenkins_home/workspace/DEV-backend-marketing-place/basecs" '
    //   }
    // }
    
    stage('Testing Project') {
      steps {
        sh 'dotnet test "/C/Windows/SysWOW64/config/systemprofile/AppData/Local/Jenkins.jenkins/workspace/DEV-backend-marketing-place/basecs.tests/basecs.tests.csproj" '
      }
    }
    
    // stage('Replacing Database Scripts') {
    //   steps {
    //     sh 'xcopy /S /E /Y "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//DEV-database-marketing-place//BACKUPDATABASEOBJECTS"  "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//DEV-backend-marketing-place//basecs" '
    //   }
    // }
	
	  stage('Stoping Docker Compose') {
      steps {
        sh 'cd basecs && docker-compose down'
      }
    }
    
    stage('Deploy Project Docker and Starting Docker Compose') {
      steps {
        sh 'cd basecs && docker-compose  up -d --build'
      }
    }
    
  }
}

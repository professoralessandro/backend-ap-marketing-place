pipeline {

  environment {
    Envronment = "${env.Envronment}";
  }

  agent any
    
  stages {

    // stage('Cloning Git') {
    //   steps {
    //     git branch: '$Branch', url: 'https://github.com/professoralessandro/backend-ap-marketing-place'
    //   }
    // }
    
    stage('Testing Project') {
      steps {
        bat 'dotnet test "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//'+Envronment+'-backend-marketing-place//basecs.tests//basecs.tests.csproj" '
      }
    }
	  
    stage('Replacing Artefacts') {
      steps {
        // REPLACE ARTEFACT FILES
        bat 'xcopy /S /E /Y "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//'+Envronment+'-artefacts-marketing-place//Environments//backend-mkt-dev"  "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//'+Envronment+'-backend-marketing-place" '
        
        // REPLACE ENTRYPOINT SH SCRIPT
        bat 'xcopy /S /E /Y "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//Environments//'+Envronment+'//backend-mkt"  "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//'+Envronment+'-backend-marketing-place" '
        
        // REPLACE DATABASE SCRIPTS
        bat 'xcopy /S /E /Y "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//'+Envronment+'-database-marketing-place//BACKUPDATABASEOBJECTS"  "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//'+Envronment+'-backend-marketing-place" '
      }
    }
    
    stage('Stoping Docker Compose') {
      steps {
         bat 'docker-compose down'
      }
    }

    stage('Deploy Project Docker and Starting Docker Compose') {
      steps {
        bat 'docker-compose  up -d --build'
      }
    }
    
  }
}

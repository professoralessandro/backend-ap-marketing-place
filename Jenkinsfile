pipeline {

  environment {
    Envronment = "${env.Envronment}";
    ProjectPath = "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//"+ Envronment +"-backend-marketing-place";
  }

  agent any
    
  stages {
    
    stage('Testing Project') {
      steps {
        bat 'dotnet test "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//'+ Envronment +'-backend-marketing-place//basecs.tests//basecs.tests.csproj" '
      }
    }
	  
    stage('Replacing Artefacts') {
      steps {
        // REPLACE ARTEFACT FILES
        bat 'xcopy /S /E /Y "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//'+ Envronment +'-artefacts-marketing-place//Environments//backend-mkt-dev"  '+ ProjectPath +' '
        
        // REPLACE ENTRYPOINT SH SCRIPT
        bat 'xcopy /S /E /Y "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//Environments//'+ Envronment +'//backend-mkt"  '+ ProjectPath +' '
        
        // REPLACE DATABASE SCRIPTS
        bat 'xcopy /S /E /Y "C://Windows//SysWOW64//config//systemprofile//AppData//Local//Jenkins.jenkins//workspace//'+ Envronment +'-database-marketing-place//BACKUPDATABASEOBJECTS"  '+ ProjectPath +' '
      }
    }

    stage('Restore Project') {
      steps {
         bat 'cd basecs && dotnet restore'
      }
    }
    
    // stage('Stoping Docker Compose') {
    //   steps {
    //      bat 'cd basecs && docker-compose down'
    //   }
    // }

    stage('Deploy Project Docker and Starting Docker Compose') {
      steps {
        bat 'cd basecs && docker-compose  up -d --build'
      }
    }
    
  }
}
pipeline {

  agent any
    
  stages {

    stage('Cloning Git') {
      steps {
        echo '$Branch';
        echo "${env.Branch}";
        echo "${env.Envronment}";
        echo "${env}";
        echo '$Envronment';
        echo '$Envronment';
      }
    }

    stage('Replacing Artefacts') {
      steps {
        bat "xcopy /S /E /Y C:/Windows/SysWOW64/config/systemprofile/AppData/Local/Jenkins.jenkins/workspace/${env.Envronment}-artefacts-marketing-place/Environments/backend-mkt-$env.Envronment  C:/Windows/SysWOW64/config/systemprofile/AppData/Local/Jenkins.jenkins/workspace/$env.Envronment-backend-marketing-place/basecs "
      }
    }








    // stage('Cloning Git') {
    //   steps {
    //     git branch: '$Branch', url: 'https://github.com/professoralessandro/backend-ap-marketing-place'
    //   }
    // }
    
    // stage('Testing Project') {
    //   steps {
    //     bat "dotnet test C:/Windows/SysWOW64/config/systemprofile/AppData/Local/Jenkins.jenkins/workspace/${env.Envronment}-backend-marketing-place/basecs.tests/basecs.tests.csproj "
    //   }
    // }

    // stage('Replacing Artefacts') {
    //   steps {
    //     bat 'xcopy C:/Windows/SysWOW64/config/systemprofile/AppData/Local/Jenkins.jenkins/workspace/${env.Envronment}-artefacts-marketing-place/Environments/backend-mkt-${env.Envronment} @C:/Windows/SysWOW64/config/systemprofile/AppData/Local/Jenkins.jenkins/workspace/${env.Envronment}-backend-marketing-place/basecs /C /S /E /Y '
    //   }
    // }
	  
    // stage('Replacing Artefacts') {
    //   steps {
    //     bat "xcopy /S /E /Y @"C:/Windows/SysWOW64/config/systemprofile/AppData/Local/Jenkins.jenkins/workspace/${env.Envronment}-artefacts-marketing-place/Environments/backend-mkt-${env.Envronment}" @"C:/Windows/SysWOW64/config/systemprofile/AppData/Local/Jenkins.jenkins/workspace/${env.Envronment}-backend-marketing-place/basecs" "
    //   }
    // }
	  
    // stage('Replacing Script entrypoint') {
    //   steps {
    //     bat "xcopy /S /E /Y C:/Windows/SysWOW64/config/systemprofile/AppData/Local/Jenkins.jenkins/workspace/Environments/${env.Envronment}/backend-mkt   C:/Windows/SysWOW64/config/systemprofile/AppData/Local/Jenkins.jenkins/workspace/${env.Envronment}-backend-marketing-place/basecs "
    //   }
    // }
  
    // stage('Replace Database Scripts') {
    //   steps {
    //     bat "xcopy /S /E /Y C:/Windows/SysWOW64/config/systemprofile/AppData/Local/Jenkins.jenkins/workspace/${env.Envronment}-database-marketing-place/BACKUPDATABASEOBJECTS   C:/Windows/SysWOW64/config/systemprofile/AppData/Local/Jenkins.jenkins/workspace/${env.Envronment}-backend-marketing-place/basecs "
    //   }
    // }
    
    // stage('Stoping Docker Compose') {
    //   steps {
    //    bat 'cd basecs && docker-compose down'
    //   }
    // }

    // stage('Deploy Project Docker and Starting Docker Compose') {
    //   steps {
    //     bat 'cd basecs && docker-compose  up -d --build'
    //   }
    // }
    
  }
}
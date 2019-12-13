pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        echo 'build'
      }
    }

    stage('Sensors Test') {
      parallel {
        stage('vibracion') {
          steps {
            echo 'Sensors Test'
          }
        }

        stage('opticos	') {
          steps {
            echo 'opticos	'
          }
        }

        stage('termicos') {
          steps {
            echo 'termicos'
          }
        }

      }
    }

    stage('Actuator test') {
      parallel {
        stage('motor electrico') {
          steps {
            echo 'Actuator test'
          }
        }

        stage('valvulas') {
          steps {
            echo 'valvulas'
          }
        }

      }
    }

    stage('Data test') {
      steps {
        echo 'Data test'
      }
    }

    stage('QA') {
      steps {
        echo 'QA'
      }
    }

    stage('Browser Test') {
      parallel {
        stage('edge') {
          steps {
            echo 'Deploy'
          }
        }

        stage('chrome') {
          steps {
            echo 'chrome'
          }
        }

        stage('firefox') {
          steps {
            echo 'firefox'
          }
        }

      }
    }

    stage('Deploy') {
      steps {
        echo 'Deploy'
      }
    }

  }
}
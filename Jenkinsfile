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
        stage('Sensors Test') {
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

        stage('vibracion') {
          steps {
            echo 'Vibracion'
          }
        }

      }
    }

    stage('Actuator test') {
      parallel {
        stage('Actuator test') {
          steps {
            echo 'Actuator test'
          }
        }

        stage('valvulas') {
          steps {
            echo 'valvulas'
          }
        }

        stage('motor electrico') {
          steps {
            echo 'Motor electrico'
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
        stage('Browser Test') {
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

        stage('edge') {
          steps {
            echo 'edge'
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
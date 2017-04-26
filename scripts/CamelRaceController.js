angular.module('CamelRace', [
])

.controller('CamelRaceController', ['$scope', 'wordService', '$interval', '$timeout', 
function ($scope, wordService, $interval, $timeout) {

    /////----------------------Vars-----------------------------///////////////////
    $scope.randomWord = "";
    var userWord = "";
    $scope.userInput = "";
    $scope.bar2ProgressVal = 50;
    $scope.roundTime = 10000;
    $scope.counterClass ="counter";
    $scope.winner={};
    $scope.roundStartTime = "";
    $scope.typingTime = {};

    $scope.stepsPerRound = 50;
    $scope.environment = {};
    $scope.environment.terrainType = "grassLane";

    $scope.players = [];
    var currentPlayerIndex = 0;

    $scope.counter = {};
    $scope.counter.seconds = $scope.roundTime / 1000;
    $scope.counter.countdown = function () {  
         if($scope.counter.seconds<= ($scope.roundTime/2000)){
                $scope.counterClass = "counter-danger";
            }else{
                   $scope.counterClass = "counter";
            }
        counterStopped = $timeout(function () {
            $scope.counter.seconds--;
            $scope.counter.countdown(); 
        }, 1000);
    };
    var counterStopped;
    var stopCounter = function () {
        $timeout.cancel(counterStopped);
    };

    var gameLoopEnded;
    var gameOver = function () {
        $timeout.cancel(gameLoopEnded);
    };
    $scope.game = function () {
        gameLoopEnded = $timeout(function () {
            $scope.gameLoop();
            $scope.game();
        }, 1000);
    }; 
    $scope.players[0] = {
        position: 0,
        camel: "Bacterian",
        camelImage: "images/camels/Bacterian.gif",
        type: "human",
        favTerrain: "sandLane",
        name:"you"
    };
    $scope.players[1] = {
        position: 0,
        camel: "Domestic",
        camelImage: "images/camels/Domestic.gif",
        type: "pc",
        favTerrain: "mudLane",
        name:"pc1"
    };
   
    $scope.players[2] = {
        position: 0,
        camel: "Domestic",
        camelImage: "images/camels/Dromedary.gif",
        type: "pc",
        favTerrain: "mudLane",
        name:"pc2"
    };
   

    $scope.cpu = {};
    $scope.cpu.possibleMoves = ["no", "half", "full", "turbo"];
    $scope.cpu.play = function () {
        var index = Math.floor(Math.random() * (4));
        if ($scope.cpu.possibleMoves[index] == "half") {
            $scope.players[currentPlayerIndex].position += $scope.stepsPerRound / 2;
        } else if ($scope.cpu.possibleMoves[index] == "full") {
            $scope.players[currentPlayerIndex].position += $scope.stepsPerRound;
        } else if ($scope.cpu.possibleMoves[index] == "turbo") {

            if ($scope.players[currentPlayerIndex].camelType == "Bacterian") {
                if ($scope.players[currentPlayerIndex].favTerrain == $scope.environment.terrainType)
                    $scope.players[currentPlayerIndex].position += $scope.stepsPerRound + ($scope.stepsPerRound * 30) / 100;
                else
                    $scope.players[currentPlayerIndex].position += $scope.stepsPerRound + ($scope.stepsPerRound * 15) / 100;
            }
            else if ($scope.players[currentPlayerIndex].camelType == "Domestic") {
                if ($scope.players[currentPlayerIndex].favTerrain == $scope.environment.terrainType)
                    $scope.players[currentPlayerIndex].position += $scope.stepsPerRound + ($scope.stepsPerRound * 30) / 100;
                else
                    $scope.players[currentPlayerIndex].position += $scope.stepsPerRound + ($scope.stepsPerRound * 20) / 100;
            } else if ($scope.players[currentPlayerIndex].camelType == "Dromedary") {
                if ($scope.players[currentPlayerIndex].favTerrain == $scope.environment.terrainType)
                    $scope.players[currentPlayerIndex].position += $scope.stepsPerRound + ($scope.stepsPerRound * 35) / 100;
                else
                    $scope.players[currentPlayerIndex].position += $scope.stepsPerRound + ($scope.stepsPerRound * 25) / 100;
            }
        };
    };

    $scope.isHuman = function () {
        if ($scope.players[currentPlayerIndex].type == "human") {
            return true;
        } else {
            return false;
        }
    };
    $scope.updatePlayerPosition = function () {
        var typingTime = new Date().getTime() - $scope.roundStartTime;
        if (typingTime < ($scope.roundStartTime / 2)) {
            $scope.players[currentPlayerIndex].position += $scope.stepsPerRound;
        } else if (typingTime < $scope.roundStartTime) {
            $scope.players[currentPlayerIndex].position += $scope.stepsPerRound / 2;
        }
    };
    $scope.weHaveAwinner = function () {
        for (var i = 0; i < $scope.players.length; i++) {
            if ($scope.players[i].position >= 100) {
                $scope.winner =$scope.players[i];
                return true;
            }
        }
        return false;
    };
    $scope.roundEnded = false;
    /////----------------------Functions---------------------///////////////////
    $scope.matchWords = function () {
        var firstThreeChars = userWord.substring(0, 3);
        if (firstThreeChars == $scope.randomWord) {
            return true;
        }
        return false;
    }
    var startNextRound = function () { 
        $scope.roundEnded = false;
        $scope.roundStartTime = new Date().getTime();
        currentPlayerIndex++;
        currentPlayerIndex %= $scope.players.length; //rotate
        if ($scope.players[currentPlayerIndex].type == "human") {
            stopCounter();
            $scope.counter.seconds = $scope.roundTime / 1000;
            $scope.counter.countdown();
            $scope.randomWord = wordService.generateRandomWord();
            userWord = "";
        }
    };
    $scope.updateGameLogic = function () {

        if ($scope.weHaveAwinner() == true) { 
            stopCounter();
            gameOver();
            return 0;
        }

        if ($scope.players[currentPlayerIndex].type == "human") {
            var currentTime = new Date().getTime();
            if (($scope.roundStartTime + $scope.roundTime) < currentTime) {
                $scope.roundEnded = true;
            }
        }

        if ($scope.players[currentPlayerIndex].type == "pc") {
            $scope.roundEnded = true;
        }

        if ($scope.roundEnded == true) {
            if ($scope.players[currentPlayerIndex].type == "human") {
                if ($scope.matchWords() == true) {
                    $scope.updatePlayerPosition();
                    var weapon = wordService.checkDoubleReversed(userWord, $scope.randomWord);
                    if (weapon == true)
                        alert("Weapon Activated!");
                }
            }
            else {
                $scope.cpu.play(); //refactor
            }
            startNextRound();
        }
    }
    $scope.gameLoop = function () {
        //take user input
        $scope.updateGameLogic();
        //draw frames
    };
    $scope.StartGame = function () {
        startNextRound();
    };
    /////----------------------Events-----------------------///////////////////
    $scope.onTyping = function (keyEvent) {
        if ($scope.players[currentPlayerIndex].type == "human") {
            if (keyEvent.which === 13) {
                $scope.roundEnded = true;
                userWord = $scope.userInput;
                $scope.userInput = "";
            }
        };
    };
    /////----------------------Excute---------------------///////////////////
    $scope.StartGame();

    $scope.game();
    ////////////////--------------progress
    $scope.progressval = 0;
    $scope.stopinterval = null;

    $scope.updateProgressbar = function () {
        startprogress();

    }

    function startprogress() {
        $scope.progressval = 0;

        if ($scope.stopinterval) {
            $interval.cancel($scope.stopinterval);
        }

        $scope.stopinterval = $interval(function () {
            $scope.progressval = $scope.progressval + 1;
            if ($scope.progressval >= 100) {
                $interval.cancel($scope.stopinterval);
                //$state.go('second');
                return;
            }
        }, 100);
    }

    startprogress();

}]);


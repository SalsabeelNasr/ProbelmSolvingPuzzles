angular.module('CamelRace').factory("wordService", function () {
    var service = {};
    service.generateRandomWord = function () {
        var text = "";
        var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        for (var i = 0; i < 3; i++)
            text += possible.charAt(Math.floor(Math.random() * possible.length));
        return text;
    };
    service.checkDoubleReversed = function (word, reversed) {
        var remainingChars = word.substring(3, word.length);
        if (remainingChars != "") {
            if (remainingChars.length == 3) {
                remainingChars = remainingChars.split("").reverse().join("");
                if (remainingChars == reversed) {
                    return true;
                }
                else
                    return false;
            }
        } else {
            return false;
        }
    };
    return service;
});

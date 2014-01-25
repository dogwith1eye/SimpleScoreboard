function AppDataModel() {
    var self = this,
        // Routes
        siteUrl = "http://simplescoreboard.azurewebsites.net";
    
    // Route operations
    function basketballGameUrl(sport) {
        return siteUrl + "/api/Game/BasketballGame?sport=" + (encodeURIComponent(sport));
    }

    self.toErrorsArray = function (data) {
        var errors = new Array(),
            items;

        if (!data || !data.message) {
            return null;
        }

        if (data.modelState) {
            for (var key in data.modelState) {
                items = data.modelState[key];

                if (items.length) {
                    for (var i = 0; i < items.length; i++) {
                        errors.push(items[i]);
                    }
                }
            }
        }

        if (errors.length === 0) {
            errors.push(data.message);
        }

        return errors;
    };

    // Data
    self.returnUrl = siteUrl;

    // Data access operations
    self.getBasketballGame = function (sport) {
        return $.ajax(basketballGameUrl(sport), {
            cache: false
        });
    };
}

function ScoreboardViewModel(dataModel) {
    var self = this;

    // Private operations
    function initialize() {
        dataModel.getBasketballGame('Basketball Boys')
            .done(function (data) {
                self.updating(false);
                self.bbbSport('Basketball Boys');
                self.bbbLine1(data.visitingTeam + '     ' + data.visitingScore);
                self.bbbLine2(data.homeTeam + '     ' + data.homeScore);
                self.bbbStatus(data.status);
            }).fail(function () {
                self.updating(false);
                self.errors.push("An unknown error occurred.");
            });
        dataModel.getBasketballGame('Basketball Girls')
            .done(function (data) {
                self.updating(false);
                self.bbgSport('Basketball Girls');
                self.bbgLine1(data.visitingTeam + '     ' + data.visitingScore);
                self.bbgLine2(data.homeTeam + '     ' + data.homeScore);
                self.bbgStatus(data.status);
            }).fail(function () {
                self.updating(false);
                self.errors.push("An unknown error occurred.");
            });
    }

    // Data
    self.bbbSport = ko.observable("");
    self.bbbLine1 = ko.observable("");
    self.bbbLine2 = ko.observable("");
    self.bbbStatus = ko.observable("");
    self.bbgSport = ko.observable("");
    self.bbgLine1 = ko.observable("");
    self.bbgLine2 = ko.observable("");
    self.bbgStatus = ko.observable("");

    // Other UI state
    self.errors = ko.observableArray();
    self.updating = ko.observable(true);

    initialize();
}

$(function () {

    var scoreboard = new ScoreboardViewModel(new AppDataModel());
    
    // Activate Knockout
    ko.applyBindings(scoreboard);

    $.connection.hub.url = 'http://simplescoreboard.azurewebsites.net/signalr'
    var hub = $.connection.gameHub;

    hub.client.basketballGameSaved = function (data) {
        if (data.Sport === 'Basketball Boys') {
            scoreboard.bbbSport('Basketball Boys');
            scoreboard.bbbLine1(data.VisitingTeam + '     ' + data.VisitingScore);
            scoreboard.bbbLine2(data.HomeTeam + '     ' + data.HomeScore);
            scoreboard.bbbStatus(data.Status);
        } else {
            scoreboard.bbgSport('Basketball Girls');
            scoreboard.bbgLine1(data.VisitingTeam + '     ' + data.VisitingScore);
            scoreboard.bbgLine2(data.HomeTeam + '     ' + data.HomeScore);
            scoreboard.bbgStatus(data.Status);
        }
    };
    // Start the connection.
    $.connection.hub.start().done(function () {
    }).fail(function (reason) {
        console.log("SignalR connection failed: " + reason);
    });

});

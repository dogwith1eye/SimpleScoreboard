$(function () {
    app.initialize();

    // Activate Knockout
    ko.applyBindings(app);

    var hub = $.connection.gameHub;
    
    hub.client.basketballGameSaved = function (data) {
        if (app.scoreboard() !== null) {
            if (data.Sport === 'Basketball Boys') {
                app.scoreboard().bbbSport('Basketball Boys');
                app.scoreboard().bbbLine1(data.VisitingTeam + '     ' + data.VisitingScore);
                app.scoreboard().bbbLine2(data.HomeTeam + '     ' + data.HomeScore);
                app.scoreboard().bbbStatus(data.Status);
            } else {
                app.scoreboard().bbgSport('Basketball Girls');
                app.scoreboard().bbgLine1(data.VisitingTeam + '     ' + data.VisitingScore);
                app.scoreboard().bbgLine2(data.HomeTeam + '     ' + data.HomeScore);
                app.scoreboard().bbgStatus(data.Status);
            }
        }
    };
    // Start the connection.
    $.connection.hub.start().done(function () {
    }).fail(function (reason) {
        console.log("SignalR connection failed: " + reason);
    });

});

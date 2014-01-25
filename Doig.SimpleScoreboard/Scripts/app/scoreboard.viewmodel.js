function ScoreboardViewModel(app, dataModel) {
    var self = this;

    // Private operations
    function initialize() {
        dataModel.getBasketballGame('Basketball Boys')
            .done(function (data) {
                console.log(data);
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
                console.log(data);
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

app.addViewModel({
    name: "Scoreboard",
    bindingMemberName: "scoreboard",
    factory: ScoreboardViewModel
});
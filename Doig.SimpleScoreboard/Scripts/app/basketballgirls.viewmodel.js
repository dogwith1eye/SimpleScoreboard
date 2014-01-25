function BasketballgirlsViewModel(app, dataModel) {
    var self = this;

    // Private operations
    function initialize() {
        dataModel.getBasketballGame('Basketball Girls')
            .done(function (data) {
                self.updating(false);
                self.visitingTeam(data.visitingTeam);
                self.visitingScore(data.visitingScore);
                self.homeTeam(data.homeTeam);
                self.homeScore(data.homeScore);
                self.status(data.status);
            }).fail(function () {
                self.updating(false);
                self.errors.push("An unknown error occurred.");
            });
    }

    // Data
    self.visitingTeam = ko.observable("");
    self.visitingScore = ko.observable(0);
    self.homeTeam = ko.observable("");
    self.homeScore = ko.observable(0);
    self.status = ko.observable("");

    // Other UI state
    self.errors = ko.observableArray();
    self.updating = ko.observable(true);

    // Operations
    self.update = function () {
        self.errors.removeAll();
        self.updating(true);
        console.log(dataModel);
        dataModel.saveBasketballGame({
            visitingTeam: self.visitingTeam(),
            visitingScore: self.visitingScore(),
            homeTeam: self.homeTeam(),
            homeScore: self.homeScore(),
            status: self.status(),
            sport: 'Basketball Girls'
        }).done(function (data) {
            self.updating(false);
        }).failJSON(function (data) {
            var errors;

            self.updating(false);
            errors = dataModel.toErrorsArray(data);

            if (errors) {
                self.errors(errors);
            } else {
                self.errors.push("An unknown error occurred.");
            }
        });
    };

    initialize();
}

app.addViewModel({
    name: "Basketballgirls",
    bindingMemberName: "basketballgirls",
    factory: BasketballgirlsViewModel
});
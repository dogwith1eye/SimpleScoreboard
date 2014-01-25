function HomeViewModel(app, dataModel) {
    var self = this;

    self.basketballBoys = function () {
        app.navigateToBasketballboys();
    };

    self.basketballGirls = function () {
        app.navigateToBasketballgirls();
    };
}

app.addViewModel({
    name: "Home",
    bindingMemberName: "home",
    factory: HomeViewModel
});

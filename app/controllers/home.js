const mongoose = require("mongoose");
const Company = mongoose.model("Company");

exports.get = ("/", (req, res, next) => {
	Company.find((err, companies) => {
		if (err) return next(err);
		res.render("index", {
			title: "Simples Justiça",
			companies: companies
		});
	});
});

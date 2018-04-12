const express = require("express");
const router = express.Router();
const mongoose = require("mongoose");
const Company = mongoose.model("Company");

router.get("/", (req, res, next) => {
	Company.find((err, companies) => {
		if (err) return next(err);
		res.render("index", {
			title: "Generator-Express MVC",
			companies: companies
		});
	});
});

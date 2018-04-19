const mongoose = require("mongoose");

exports.get = (req, res) => {
	res.render("index", {
		title: "Simples Justiça"
	});
};

const mongoose = require("mongoose");
const Company = mongoose.model("Company");

exports.list = (req, res) => {
};

exports.details = (req, res) => {
};

exports.form = (req, res) => {
	res.render('company/form');
};

exports.create = (req, res) => {
	var company = new Company(req.body);
	company.save()
		.then(x => {
			res.render('../views/index.hbs', {
				title: "Simples Justiça"
			});
		})
		.catch(err => {
			res.render('error', {
				message: 'Erro ao cadastrar empresa',
				stack: err
			});
		});
};

exports.edit = (req, res) => {
};

exports.remove = (req, res) => {
};

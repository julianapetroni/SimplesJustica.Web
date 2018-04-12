const mongoose = require("mongoose");
const Company = mongoose.model("Company");

exports.get = (req, res, next) => {
	Company.find({}, "nameAlias address lineOfBusinessId")
		.then(data => {
			res.status(200).send(data);
		})
		.catch(err => {
			res.status(400).send(err);
		});
};

exports.post = (req, res, next) => {
	const company = new Company(req.body);
	company.save()
		.then(data => {
			res.status(201).send({
				mensagem: "Empresa cadastrada com sucesso."
			});
		})
		.catch(e => {
			res.status(400).send({
				mensagem: "Falha ao cadastrar uma empresa",
				data: e
			});
		});
};

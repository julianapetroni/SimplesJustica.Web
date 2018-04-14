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

exports.getById = (req, res, next) => {
	Company.findById(req.params.id)
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

exports.put = (req, res, next) => {
	Company
		.findByIdAndUpdate(req.params.id,{
			$set: {
				nameAlias: req.body.nameAlias,
				name: req.body.name,
				email: req.body.email,
				address: req.body.address,
				lineOfBusinessId: req.body.lineOfBusinessId
			}
		})
		.then(data => {
			res.status(201).send({
				mensagem: "Empresa atualizada com sucesso."
			});
		})
		.catch(e => {
			res.status(400).send({
				mensagem: "Falha ao atualizar uma empresa",
				data: e
			});
		});
};

exports.delete = (req, res, next) => {
	Company
		.findOneAndRemove(req.params.id)
		.then(data => {
			res.status(201).send({
				mensagem: "Empresa deletada com sucesso."
			});
		})
		.catch(e => {
			res.status(400).send({
				mensagem: "Falha ao deletar uma empresa",
				data: e
			});
		});
};

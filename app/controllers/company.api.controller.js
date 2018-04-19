const mongoose = require("mongoose");
const Company = mongoose.model("Company");

exports.get = (req, res) => {
	Company.find({}, 'nameAlias email cnpj ie')
		.then(data => {
			res.status(200).send(data);
		})
		.catch(err => {
			res.status(400).send(err);
		});
};

exports.getById = (req, res) => {
	Company.findById(req.params.id).populate('lineOfBusiness')
		.then(data => {
			res.status(200).send(data);
		})
		.catch(err => {
			res.status(400).send(err);
		});
};

exports.post = (req, res) => {
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

exports.put = (req, res) => {
	Company
		.findByIdAndUpdate(req.params.id,{
			$set: {
				nameAlias: req.body.nameAlias,
				name: req.body.name,
				email: req.body.email,
				address: req.body.address,
				lineOfBusiness: req.body.lineOfBusiness
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

exports.delete = (req, res) => {
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

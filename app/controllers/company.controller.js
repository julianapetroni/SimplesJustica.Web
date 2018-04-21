const mongoose = require("mongoose");
const Company = mongoose.model("Company");

exports.list = (req, res) => {
	Company.find({}, 'nameAlias name email cnpj ie')
		.then(data => {
			res.render('company/list', {
				title: "Listagem",
				companies: data
			});
		})
		.catch(err => {
			res.render('error', {
				message: err
			});
		});
};

exports.form = (req, res) => {
	res.render('company/form', {
		title: "Cadastrar",
		company: {}
	});
};

exports.details = (req, res) => {
	Company.findById(req.params.id)
	.then(data => {
		res.render('company/form', {
			company: data,
			title: "Detalhes"
		});
	})
	.catch(err => {
		res.render('error', {
			message: err
		});
	});
};

exports.create = (req, res) => {
	var company = new Company(req.body);
	company.save()
		.then(x => {
			res.render('index', {
				title: "Simples Justiça",
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
	Company
		.findByIdAndUpdate(req.params.id,{
			$set: {
				nameAlias: req.body.nameAlias,
				name: req.body.name,
				email: req.body.email,
				cnpj: req.body.cnpj,
				ie: req.body.ie
			}
		})
		.then(data => {
			res.render('index');
		})
		.catch(e => {
			res.render('error', {
				message: e
			});
		});
};

exports.remove = (req, res) => {
	Company
		.findOneAndRemove(req.params.id)
		.then(data => {
			res.render('index', {
				mensagem: "Empresa deletada com sucesso."
			});
		})
		.catch(e => {
			res.render('error', {
				message: e
			});
		});
};

const mongoose = require('mongoose');
const LineOfBusiness = mongoose.model('LineOfBusiness');

exports.get = (req, res) => {
	LineOfBusiness
		.find({})
		.then(data => {
			res.status(200).send(data);
		})
		.catch(err => {
			res.status(400).send({
				mensagem: "Erro",
				data: err
			});
		});
};

exports.getById = (req, res) => {
	LineOfBusiness
		.findById(req.params.id).populate('company')
		.then(data => {
			res.status(200).send(data);
		})
		.catch(err => {
			res.status(400).send({
				mensagem: "Erro",
				data: err
			});
		});
};

exports.post = (req, res) => {
	const lob = new LineOfBusiness(req.body);
	lob.save(lob)
		.then(data => {
			res.status(201).send({
				mensagem: "Nova linha de negócios criada com sucesso"
			});
		})
		.catch(err => {
			res.status(400).send({
				mensagem: "Erro",
				data: err
			});
		});
};

exports.put = (req, res) => {
	LineOfBusiness
		.findByIdAndUpdate(req.params.id, {
			description: req.body.description
		})
		.then(data => {
			res.status(200).send({
				mensagem: "Linha de negócio atualizada com sucesso"
			});
		})
		.catch(err => {
			res.status(400).send({
				mensagem: "Erro",
				data: err
			});
		});
};

exports.delete = (req, res) => {
	LineOfBusiness
		.findByIdAndRemove(req.params.id)
		.then(data => {
			res.status(200).send({
				mensagem: "Linha de negócio removida com sucesso"
			});
		})
		.catch(err => {
			res.status(400).send({
				mensagem: "Erro",
				data: err
			});
		});
};

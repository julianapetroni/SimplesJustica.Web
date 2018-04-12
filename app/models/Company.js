const mongoose = require("mongoose");
const Schema = mongoose.Schema;

const CompanySchema = new Schema({
	nameAlias: {
		type: String,
		required: true
	},
	address: {
		type: String,
		required: true
	},
	name: {
		type: String
	},
	email: {
		type: String,
		unique: true
	},
	cnpj: {
		type: String,
		unique: true
	},
	ie: {
		type: String
	},
	lineOfBusinessId: {
		type: Number,
		required: true
	}
});

module.exports = mongoose.model("Company", CompanySchema);

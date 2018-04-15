const mongoose = require("mongoose");
const Schema = mongoose.Schema;

const CompanySchema = new Schema({
	nameAlias: {
		type: String,
		required: true
	},
	address: [{
		street:{
			type: String,
			required: true
		},
		number: {
			type: String,
			required: true
		},
		buildingComplement: {
			type: String
		},
		districtName :{
			type: String
		},
		city: {
			type: String,
			required: true
		},
		state: {
			type: String,
			required: true
		},
		country: {
			type: String,
			required: true
		}
	}],
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

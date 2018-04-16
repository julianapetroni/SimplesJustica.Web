const mongoose = require("mongoose");
const Schema = mongoose.Schema;

const CompanySchema = new Schema({
	nameAlias: {
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
	address: {
		street: {
			type: String,
			required: true
		},
		num: {
			type: Number,
			required: true
		},
		complement: {
			type: String,
		},
		neighborhood: {
			type: String,
			required: true
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
		},
		cep: {
			type: String,
			required: true
		}
	},
	lineOfBusiness: {
		type: mongoose.Schema.Types.ObjectId,
		ref: 'LineOfBusiness'
	},
	createdDate: {
		type: Date,
		required: true,
		default: Date.now
	}
});

CompanySchema.virtual('date')
	.get(() => this._id.getTimestamp());

module.exports = mongoose.model("Company", CompanySchema);

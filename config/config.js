const path = require("path");
const rootPath = path.normalize(__dirname + "/..");
const env = process.env.NODE_ENV || "development";

const config = {
	development: {
		root: rootPath,
		app: {
			name: "simplesjustica-web"
		},
		port: process.env.PORT || 3000,
		db: "mongodb://localhost/simplesjustica-web-development"
	},

	test: {
		root: rootPath,
		app: {
			name: "simplesjustica-web"
		},
		port: process.env.PORT || 3000,
		db: "mongodb://localhost/simplesjustica-web-test"
	},

	production: {
		root: rootPath,
		app: {
			name: "simplesjustica-web"
		},
		port: process.env.PORT || 3000,
		db: "mongodb://localhost/simplesjustica-web-production"
	}
};

module.exports = config[env];

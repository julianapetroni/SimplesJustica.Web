const express = require('express');
const router = express.Router();
const controller = require('../controllers/company.controller');

router.get('/cadastrar', controller.form);


module.exports = (app) => {
	app.use('/empresa', router);
};

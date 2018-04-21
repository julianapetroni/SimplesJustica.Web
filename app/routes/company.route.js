const express = require('express');
const router = express.Router();
const controller = require('../controllers/company.controller');

router.get('/cadastrar', controller.form);
router.post('/cadastrar', controller.create);

module.exports = (app) => {
	app.use('/empresa', router);
};

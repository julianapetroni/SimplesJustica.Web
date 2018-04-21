const express = require('express');
const router = express.Router();
const controller = require('../controllers/company.controller');

router.get('/', controller.list);
router.get('/cadastrar', controller.form);
router.post('/cadastrar', controller.create);
router.get('/:id', controller.details);
router.put('/:id', controller.edit);
router.delete('/:id', controller.remove);

module.exports = (app) => {
	app.use('/empresa', router);
};

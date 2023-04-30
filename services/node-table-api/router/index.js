const Router = require('express');
const tableController = require('../controllers/table-controller');
const {body} = require('express-validator');

const router = new Router();

router.post('/table', tableController.create);

module.exports = router;

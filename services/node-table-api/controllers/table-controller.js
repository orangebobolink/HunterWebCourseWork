const tableService = require('../services/table-service');
const {validationResult} = require('express-validator');
const ApiError = require('../exceptions/api-error');

class TableController {
    async create(req, res, next) {
        try {
            const {_id,name, rows} = req.body;

            const product = await tableService.create(name, rows);

            return res.json(product);
        } catch (e) {
            next(e);
        }
    }
}

module.exports = new TableController();
const TableModel = require('../models/table-model');
const ApiError = require('../exceptions/api-error');

class TableService {
    async create(name, rows) {
        const candidate = await TableModel.findOne({name});

        if (candidate) {
            throw ApiError.BadRequest('Такая таблица уже существует уже существует');
        }

        const table = await TableModel.create({
            name,
            rows
        });

        return {
            table
        };
    }

    async update(id, name, rows) {
        const table = await TableModel.findById(id);

        table.name = name;
        table.rows  = rows;

        table.save();

        return {
            table
        };
    }

    async delete(id) {
        const prod = await ProductModel.deleteOne({_id: id});

        return prod;
    }

    async getProducts() {
        const products = await ProductModel.find();

        return products;
    }

    async getProductById(id) {
        const product = await ProductModel.findById(id);

        return product;
    }
}

module.exports = new TableService();
const {Schema, model} = require('mongoose');

const TableSchema = new Schema({
    name: {type: String, unique: true, required: true},
    rows: [{
        sequence_number : {type:Number},
        title: {type: String, unique: true, required: true},
        cost: {type: String, unique: true, required: false},
        subrows: [{
            sequence_number : {type:Number},
            title: {type: String, unique: true, required: true},
            cost: {type: String, unique: true, required: true},
        }]
    }]
});

module.exports = model('Table', TableSchema);

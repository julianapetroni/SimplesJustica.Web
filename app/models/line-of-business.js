const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const lineofbusinessSchema = new Schema({
    description: {
        type: String,
        required: true
    }
});

module.exports = mongoose.model('LineOfBusiness', lineofbusinessSchema);

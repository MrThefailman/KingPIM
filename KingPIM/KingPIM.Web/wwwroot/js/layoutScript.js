$(document).ready(function () {

    M.updateTextFields();

    var sidebar = $('.collapsible');
    var SBInstances = M.Collapsible.init(sidebar/*, options*/);

    var loginModal = $('#loginModal');
    var LMInstances = M.Modal.init(loginModal/*, options*/);

    //Start of Category JS script
    var createCategoryModal = $('#createCategoryModal');
    var CCMInstances = M.Modal.init(createCategoryModal/*, options*/);

    var deleteCategoryModal = $('#deleteCategoryModal');
    var DCMInstances = M.Modal.init(deleteCategoryModal/*, options*/);

    var editCategoryModal = $('#editCategoryModal');
    var ECMInstances = M.Modal.init(editCategoryModal/*, options*/);

    $('.deleteCat').click(function () {

        var categoryId = $(this).data('id');
        var deleteInput = $('.deleteCategoryModalInput').attr('value', categoryId);

    });

    $('.editCat').click(function () {

        var categoryId = $(this).data('id');
        var categoryName = $(this).data('name');
        var editInput = $('.editCategoryModalInput').attr('value', categoryId);
        var editName = $('.editCategoryModalValue').attr('value', categoryName);

        M.updateTextFields();

    });

    // Start of subcategory JS script
    var createSubcategoryModal = $('#createSubcategoryModal');
    var CSMInstances = M.Modal.init(createSubcategoryModal/*, options*/);

    // Category select
    var categorySelect = $('.categoryselect');
    var CSInstances = M.FormSelect.init(categorySelect/*, options*/);

    var createSubcategorySubmit = $('#createSubcategorySubmit');
    createSubcategorySubmit.hide();

    categorySelect.on('change', () => {
        createSubcategorySubmit.show();
    });

    var editSubcategoryModal = $('#editSubcategoryModal');
    var ESMInstances = M.Modal.init(editSubcategoryModal/*, options*/);

    var deleteSubcategoryModal = $('#deleteSubcategoryModal');
    var DSMInstances = M.Modal.init(deleteSubcategoryModal/*, options*/);

    $('.deleteSubcat').click(function () {
        var subcategoryId = $(this).data('id');
        var deleteInput = $('.deleteSubcategoryModalInput').attr('value', subcategoryId);
    });

    $('.editSubcat').click(function () {

        var subcategoryId = $(this).data('id');
        var subcategoryName = $(this).data('name');
        var editInput = $('.editSubcategoryModalInput').attr('value', subcategoryId);
        var editName = $('.editSubcategoryModalValue').attr('value', subcategoryName);

        M.updateTextFields();

    });

    // Start of product JS script
    var CreateProductModal = $('#createProductModal');
    var CPInstances = M.Modal.init(CreateProductModal/*, options*/);

    // Subcategory select
    var subcategorySelect = $('.subcategoryselect');
    var SSInstances = M.FormSelect.init(subcategorySelect/*, options*/);

    var createProductSubmit = $('#createProductSubmit');
    createProductSubmit.hide();

    subcategorySelect.on('change', () => {
        createProductSubmit.show();
    });

    var editProductModal = $('#editProductModal');
    var EPInstances = M.Modal.init(editProductModal/*, options*/);

    var deleteProductModal = $('#deleteProductModal');
    var DPInstances = M.Modal.init(deleteProductModal/*, options*/);

    $('.deleteProd').click(function () {
        var productId = $(this).data('id');
        var deleteInput = $('.deleteProductModalInput').attr('value', productId);
    });

    $('.editProd').click(function () {

        $('.editProductModalDescription').empty();
        var productId = $(this).data('id');
        var productName = $(this).data('name');
        var productPrice = $(this).data('price');
        var productDescription = $(this).data('description');

        var editInput = $('.editProductModalInput').attr('value', productId);
        var editName = $('.editProductModalValue').attr('value', productName);
        var editPrice = $('.editProductModalPrice').attr('value', productPrice);
        var editDescription = $('.editProductModalDescription').val(productDescription);

        M.updateTextFields();
        M.textareaAutoResize($('.editProductModalDescription'));
    });

    // Existing attributes select
    var attributeSelect = $('#attribute-select');
    var ASInstances = M.FormSelect.init(attributeSelect/*, options*/);

    // Create attribute modal
    var createAttributeModal = $('#createAttributeModal');
    var CAMInstances = M.Modal.init(createAttributeModal/*, options*/);

    // Attribute type selector
    var attrTypeSelect = $('.attrTypeSelect');
    var ATSInstances = M.FormSelect.init(attrTypeSelect/*, options*/);

    var createAttributeName = $('#create-attribute-name');

    // choose existing attributegroups
    attributeSelect.on('change', function () {
        var value = $(this).val();

        $('#sub-attribute-container').empty();

        var attrConInput = $('#attribute-container-input');
        console.log(attrConInput.val() + value);

        attrConInput.val(value);

        var part = value.split('%');

        var name = part[0];
        var data = part[1];

        $('#sub-attribute-container').append(
            '<div class="chip"><span class="value" data-value="' + data + '">'
            + name
            + '</span><i class="material-icons close">close</i></div>'
        );
    });

    var existingAttributesSelect = $('#existingAttributes');
    EASInstance = M.FormSelect.init(existingAttributesSelect);

    //$('select').FormSelect();

    // Choose existing attributes.
    $('#existingAttributes').change((x) => {
        //var customAttribute = EASInstance[0].getSelectedValues();
        var customAttribute = existingAttributesSelect.find(':selected').val();

        console.log(customAttribute);
        var splitted = customAttribute.split('¤');
        customAttributeName = splitted[0];
        customAttributeOptions = splitted[1];
        $('#attribute-container').append(
            // TODO: make it work like Create attribute function
            '<div class="chip"><span class="value" data-value="' + customAttributeOptions + '">'
            + customAttributeName
            + '</span><i class="material-icons close">close</i><div>'
        );
    });

    // Create attribute function
    $('button#create-attribute-button').click(function () {
        var attributeName = $('#create-attribute-name').val();
        var attributeValue = $('#attributeType-select').val();

        $('#attribute-container').append(
            '<div class="chip"><span class="value" data-value="' + attributeValue + '">'
            + attributeName
            + '</span><i class="material-icons close">close</i></div>'
        );


        $('#create-attribute-name').val('');
    });

    // Save attributes function
    $('#save-attributes').click(function () {

        $('#sub-attribute-container').empty();

        var test = $('#attribute-container').children();

        var attributeGroupName = $('#attribute-group-name').val();

        var attrArray = [];

        $.each(test, function (i, attribute) {
            var text = $(attribute).find('span.value').text();
            var value = $(attribute).find('span.value').data('value');
            if (text && value && attributeGroupModal) {
                attrArray.push(text + '=' + value);
                console.log(text + '=' + value);
            }
        });

        console.log(attrArray);

        var stringvalue = attrArray.join('|');

        console.log(attributeGroupName + '%' + stringvalue);

        var AttrConInput = $('#attribute-container-input');

        AttrConInput.attr('value', attributeGroupName + '%' + stringvalue);

        $('#sub-attribute-container').append(
            '<div class="chip"><span class="value" data-value="' + stringvalue + '">'
            + attributeGroupName
            + '</span><i class="material-icons close">close</i></div>'
        );

    });

    // Attributegroup modal
    var attributeGroupModal = $('#createAttributeGroupModal');
    var AGMInstances = M.Modal.init(attributeGroupModal/*, options*/);

    var addAttributeGroup = $('#add-attribute-group');

    // Send attributeGroup to subcategory modal
    addAttributeGroup.click(function () {
        var AttrGroupAttributeName = $('#AttrGroup-attribute-name').val();
        var attributeTypeGroup = $('#attributeType-group').val();

        $('#attribute-group-attributes').append(
            '<div class="chip"><span class="value" data-value="' + attributeTypeGroup + '">'
            + AttrGroupAttributeName
            + '</span><i class="material-icons close">close</i></div>'
        );


        $('#AttrGroup-attribute-name').val('');
        attribute - container;
    });

    var customAttributeModal = $('#CustomAttribute');
    var CostumAMInstances = M.Modal.init(customAttributeModal/*, options*/);

    // Create custom attribute Option
    var customAttributeOption = $('#AddCustomAttributeOption');
    customAttributeOption.click(function () {
        var attributename = $('#PreDefinedOptionName').val();
        $('#predefinedOptions-container').append(
            `<div class="chip"><span class="custom">${attributename}</span><i class="material-icons close">close</i></div>`
        );
        $('#PreDefinedOptionName').val('');
    });

    $('#createCustomAttributeGroup').click(function () {

        $('#customPredefinedAttributeGroupContainer').empty();

        var PredefinedName = $('#PreDefinedName').val();
        var PredefinedOptions = $('#predefinedOptions-container').children();

        var customArray = [];

        $.each(PredefinedOptions, function (i, option) {

            var customOption = $(option).find('span.custom').text();

            customArray.push(customOption);
        });

        var stringValue = customArray.join('|');

        $('#PredefinedAttributeGroup').attr('value', `${PredefinedName}%${stringValue}`);

        $('#customPredefinedAttributeGroupContainer').append(
            `<div class="chip"><span class="custom" data-value="${stringValue}">${PredefinedName}</span><i class="material-icons close">close</i></div>`
        );

        $('#predefinedOptions-container').empty();
        $('#PreDefinedOptionName').val('');
        $('#PreDefinedName').val('');
    });

    $('#saveCustomAttributeGroup').click(function () {

        $('#predefinedOptions-container').empty();
    });

});
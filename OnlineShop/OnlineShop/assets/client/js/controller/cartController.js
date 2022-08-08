﻿var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });

        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/payment";
        });

        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.quantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        ID: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true)
                    {
                        window.location.href = "/cart";
                    }                  
                }
            });
        });

        $('.plus').off('click').on('click', function (e) {
            e.preventDefault();
            var listProduct = $('.quantity');
            
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: parseInt($(item).val()) + 1,
                    Product: {
                        ID: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/cart";
                    }
                }
            });
        });

        $('.minus').off('click').on('click', function (e) {
            e.preventDefault();
            var listProduct = $('.quantity');
            
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: parseInt($(item).val()) - 1,
                    Product: {
                        ID: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/cart";
                    }
                }
            });
        });

        $('#btnDeleteAll').off('click').on('click', function () {
            $.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/cart";
                    }
                }
            });
        });

        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: {id:$(this).data('id')},
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/cart";
                    }
                }
            });
        });
    }
}
cart.init();
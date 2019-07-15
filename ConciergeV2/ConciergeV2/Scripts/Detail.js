var Servicios = []
//fetch Servicios from database
function LoadServicios(element) {
    if (Servicios.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/SPA_Encabezado_Reserva/GetServicios',
            success: function (data) {
                Servicios = data;
                //render catagory
                renderServicios(element);
            }
        })
    }
    else {
        //render Servicios to the element
        renderServicios(element);
    }
}

function renderServicios(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Seleccione un elemento'));
    $.each(Servicios, function (i, val) {
        $ele.append($('<option/>').val(val.CodSer.trim()).text(val.DesSer));
    })
}

var Terapeutas = []
//fetch Terapeutas from database
function LoadTerapeutas(element) {
    if (Terapeutas.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/SPA_Encabezado_Reserva/GetTerapeutas',
            success: function (data) {
                Terapeutas = data;
                //render catagory
                renderTerapeutas(element);
            }
        })
    }
    else {
        //render Terapeutas to the element
        renderTerapeutas(element);
    }
}

function renderTerapeutas(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Seleccione un elemento'));
    $.each(Terapeutas, function (i, val) {
        $ele.append($('<option/>').val(val.CodTerap).text(val.NomTerap));
    })
}

var Salas = []
//fetch Salas from database
function LoadSalas(element) {
    if (Salas.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/SPA_Encabezado_Reserva/GetSalas',
            success: function (data) {
                Salas = data;
                //render catagory
                renderSalas(element);
            }
        })
    }
    else {
        //render Salas to the element
        renderSalas(element);
    }
}

function renderSalas(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Seleccione un elemento'));
    $.each(Salas, function (i, val) {
        $ele.append($('<option/>').val(val.CodSala).text(val.DesSala));
    })
}

//Actualizando precio
$('#Servicios').change(function () {
    $.ajax({
        async: true,
        url: "/SPA_Encabezado_Reserva/GetPrecioServicio",
        datatype: "json",
        data: {
            Servicios: $('#Servicios').val()
        },
        success: function (data) {
            $("#Precio").val(data.PreSer);
        }
    })
});

$(document).ready(function () {
    //Add button click event
    $('#Agregar').click(function () {
        //validation and add order items
        var isAllValid = true;
        if ($('#NombreHuesped').val().trim() == '') {
            isAllValid = false;
            $('#NombreHuesped').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#NombreHuesped').siblings('span.error').css('visibility', 'hidden');
        }

        if (($('#Servicios').val() == "0")) {
            isAllValid = false;
            $('#Servicios').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Servicios').siblings('span.error').css('visibility', 'hidden');
        }

        if (!($('#Precio').val().trim() != '' && !isNaN($('#Precio').val().trim()))) {
            isAllValid = false;
            $('#Precio').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Precio').siblings('span.error').css('visibility', 'hidden');
        }

        if (($('#Terapeutas').val() == "0")) {
            isAllValid = false;
            $('#Terapeutas').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Terapeutas').siblings('span.error').css('visibility', 'hidden');
        }

        if (($('#Salas').val() == "0")) {
            isAllValid = false;
            $('#Salas').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Salas').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            var $newRow = $('#mainrow').clone().removeAttr('id');
            $('.servicios', $newRow).val($('#Servicios').val());
            $('.terapeutas', $newRow).val($('#Terapeutas').val());
            $('.salas', $newRow).val($('#Salas').val());

            //Replace add button with remove button
            $('#Agregar', $newRow).addClass('remove').val('Remover').removeClass('btn-success').addClass('btn-danger');

            //remove id attribute from new clone row
            $('#NombreHuesped,#fechahora,#Servicios,#Precio,#Terapeutas,#Salas,#Notas,#Agregar', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            //append clone row
            $('#orderdetailsItems').append($newRow);

            //clear select data
            $('#Servicios,#Terapeutas,#Salas').val('0');
            $('#NombreHuesped,#Precio,#fechahora,#Notas').val('');
            $('#SpaItemError').empty();

            //Calculando total reserva
            totalReserva();
        }

    })

    //remove button click event
    $('#orderdetailsItems').on('click', '.remove', function () {
        $(this).parents('tr').remove();
        totalReserva();
    });

    $('#submit').click(function () {
        var isAllValid = true;

        var _Crear = $('#CodReserva').val() === undefined || $('#CodReserva').val() === null || parseInt($('#CodReserva').val()) < 0 ? true : false;

        //validate order items
        $('#SpanItemError').text('');
        var list = [];//Arreglo para obtener los detalles
        var numeroErrores = 0;//Variable para conteo de número de errores por detalle
        $('#orderdetailsItems tr').each(function (index, ele) {//Iterando en cada "row" de la tabla #orderdetailsItems
            if (//Validando los detalles de la tabla
                $('.hn', this).val() == "" ||
                $('.fh', this).val() == "" ||
                $('select.servicios', this).val() == "0" ||
                $('select.terapeutas', this).val() == "0" ||
                $('select.salas', this).val() == "0"
            ) {
                numeroErrores++;
                $(this).addClass('error');
            } else {
                var DetReserva = {
                    Numreg: $('.Numreg', this).val(),
                    FecHoraRes: $('.fh', this).val(),
                    CodSer: $('select.servicios', this).val().trim(),
                    CodSala: $('select.salas', this).val().trim(),
                    CodTerap: parseInt($('select.terapeutas', this).val()),
                    Notas: $('.notas', this).val(),
                    NomHues: $('.hn', this).val()
                }
                list.push(DetReserva);
            }
        })

        if (numeroErrores > 0) {
            $('#SpanItemError').text("Se han encontrado " + numeroErrores + " errores");
            isAllValid = false;
        }

        if (list.length == 0) {
            $('#SpanItemError').text('Se debe agregar por lo menos un detalle a la reserva');
            isAllValid = false;
        }

        if ($('#NomHuesped').val().trim() == '') {
            $('#NomHuesped').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#NomHuesped').siblings('span.error').css('visibility', 'hidden');
        }

        //if ($('#orderDate').val().trim() == '') {
        //    $('#orderDate').siblings('span.error').css('visibility', 'visible');
        //    isAllValid = false;
        //}
        //else {
        //    $('#orderDate').siblings('span.error').css('visibility', 'hidden');
        //}

        if (isAllValid) {
            var data =
            {
                CodReserva: $('#CodReserva').val(),
                ReservaOpera: $('#ReservaOpera').val(),
                NomHuesped: $('#NomHuesped').val(),
                NumRoom: $('#NumRoom').val(),
                Checkin: $('#Checkin').val(),
                Checkout: $('#Checkout').val(),
                FecReg: $('#FecReg').val(),
                Alergias: $('#Alergias').val(),
                Observaciones: $('#Observaciones').val(),
                NotasCliente: $('#NotasCliente').val(),
                Email: $('#Email').val(),
                SPA_Detalle_Reserva: list
            }

            $(this).val('Espere por favor...');

            $.ajax({
                type: 'POST',
                url: _Crear === true ? '/SPA_Encabezado_Reserva/GuardarReserva' : '/SPA_Encabezado_Reserva/ActualizarReserva',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        alert('Reserva almacenada exitosamente');
                        //here we will clear the form
                        list = [];
                        $('#Servicios,#Terapeutas,#Salas').val('0');
                        $('#NombreHuesped,#Precio,#fechahora,#Notas').val('');
                    }
                    else {
                        alert('Error');
                    }
                    $('#submit').text('Save');
                    window.location.replace("/SPA_Encabezado_Reserva/Index");
                },
                error: function (error) {
                    console.log(error);
                    $('#submit').text('Save');
                }
            });
        }

    });

});

function totalReserva() {
    var total = 0;
    $('#orderdetailsItems tr').each(function (index, ele) {//Iterando en cada "row" de la tabla #orderdetailsItems
        if (//Validando los detalles de la tabla
            total += (parseFloat($('.precio', this).val()))
        );
    });
    $("#TotalReserva").val(total);
}

LoadServicios($('#Servicios'));
LoadTerapeutas($('#Terapeutas'));
LoadSalas($('#Salas'));
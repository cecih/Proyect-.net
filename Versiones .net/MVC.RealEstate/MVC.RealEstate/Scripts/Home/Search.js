$(function () {
  
    $("#btnSearch").click(function () {
        if (jQuery("#cityID").val() == null) {
            alert("Debe seleccionar una ciudad");
            return false;
        }
        //verifica que ingresa al menos 3 caracteres en la busqueda
        if (jQuery("#btnSearch").val.length < 3)
            alert("Debe ingresar al menos 3 letras");
        
    });
    
    $("#cityDescription").autocomplete({
        source: function (request, response) {
            //muestra los primeros 50 caracteres de la descripcion
            //y los concatena con la string "..."
            (String.prototype.substr(jquery("Description"), 50)).concat("...");
            onDataSource(request, response);
        },
        select: function (event, ui) { //item consigna Home
            jQuery("#cityID").val(ui.item.value);
            ui.item.value = ui.item.label;
            jQuery("Published").filter(Published = true);
            jQuery("Featured").filter(Featured = true);
            jQuery("Price").filter(Price > 5000);
        },
        focus: function(event, ui) {
        event.preventDefault();
        this.value = ui.item.label;
        },

        
    });
});

function onDataSource(request, response) {
    jQuery.ajax({
        url: "/City/GetCities",
        dataType: "json",
        data: {
            partialDescription: request.term
        },
        success: function (data) {
            response(jQuery.map(data, function (item) {
                return {
                    label: item.Description,
                    value: item.CityID
                }
            }));
        }
    });
}
nombre=(input("ingrese su nombre: "));
cantidad=int(input("ingrese la cantidad de pantalones: "));
precio=160.50;
subtotal=precio*cantidad;
if cantidad> 10:
    total=subtotal*0.25;
    descuento=subtotal-total;
    mensaje0="el subtotal es de: ",subtotal;
    mensaje="el descuento es de: ",descuento;
    mensaje2=" el total es de: ",total;
elif cantidad>7:
    total = subtotal * 0.1;
    descuento = subtotal-total;
    mensaje0 = "el subtotal es de: ",subtotal;
    mensaje = "el descuento es de: ",descuento;
    mensaje2 = " el total es de: ",total;
elif subtotal>700:
    total = subtotal * 0.05;
    descuento = subtotal-total;
    mensaje0 = "el subtotal es de: ",subtotal;
    mensaje = "el descuento es de: ",descuento;
    mensaje2 = " el total es de: ",total;
else:
    mensaje0 = "el subtotal es de: ",subtotal;
    mensaje="no hubo descuento";
    mensaje2 = "el total es de: ",subtotal;
print(mensaje0)
print(mensaje);
print(mensaje2);

<%@ Page Title="EcoRecicla" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EcoReciclaje._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta charset="utf-8" />

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <title>EcoRecicla</title>

    <link href="Estilo/EcoRecicla.css" rel="stylesheet" />

</head>
<body>

    <form id="form1" runat="server">

        <main class="eco-container">

            <!-- ENCABEZADO -->

            <section class="eco-header">

                <h1>♻️ EcoRecicla</h1>

                <p>Sistema de Gestión de Reciclaje</p>

                <span>
                    Registra los materiales reciclados y contribuye
                    al cuidado del medio ambiente.
                </span>

            </section>


            <!-- GESTIÓN DE USUARIOS -->

            <section class="eco-form">

                <h2>Gestión de usuarios</h2>

                <div class="form-group">

                    <label for="txtIdUsuario">
                        ID interno
                    </label>

                    <asp:TextBox
                        ID="txtIdUsuario"
                        runat="server"
                        CssClass="form-control"
                        placeholder="ID para actualizar o eliminar">
                    </asp:TextBox>

                </div>


                <div class="form-group">

                    <label for="txtCedulaUsuario">
                        Cédula
                    </label>

                    <asp:TextBox
                        ID="txtCedulaUsuario"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Ejemplo: 1-2345-6789">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator
                        ID="valCedulaUsuario"
                        runat="server"
                        ControlToValidate="txtCedulaUsuario"
                        ErrorMessage="La cédula es obligatoria."
                        CssClass="mensaje-error"
                        Display="Dynamic"
                        ValidationGroup="Usuario">
                    </asp:RequiredFieldValidator>

                </div>


                <div class="form-group">

                    <label for="txtNombreUsuario">
                        Nombre
                    </label>

                    <asp:TextBox
                        ID="txtNombreUsuario"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Nombre del usuario">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator
                        ID="valNombreUsuario"
                        runat="server"
                        ControlToValidate="txtNombreUsuario"
                        ErrorMessage="El nombre es obligatorio."
                        CssClass="mensaje-error"
                        Display="Dynamic"
                        ValidationGroup="Usuario">
                    </asp:RequiredFieldValidator>

                </div>


                <div class="form-group">

                    <label for="txtCorreoUsuario">
                        Correo
                    </label>

                    <asp:TextBox
                        ID="txtCorreoUsuario"
                        runat="server"
                        CssClass="form-control"
                        placeholder="correo@ejemplo.com">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator
                        ID="valCorreoUsuario"
                        runat="server"
                        ControlToValidate="txtCorreoUsuario"
                        ErrorMessage="El correo es obligatorio."
                        CssClass="mensaje-error"
                        Display="Dynamic"
                        ValidationGroup="Usuario">
                    </asp:RequiredFieldValidator>

                </div>


                <div class="form-group">

                    <asp:Button
                        ID="btnAgregarUsuario"
                        runat="server"
                        Text="Agregar usuario"
                        CssClass="btn-eco"
                        OnClick="btnAgregarUsuario_Click"
                        ValidationGroup="Usuario" />

                    <asp:Button
                        ID="btnActualizarUsuario"
                        runat="server"
                        Text="Actualizar usuario"
                        CssClass="btn-eco"
                        OnClick="btnActualizarUsuario_Click"
                        CausesValidation="false" />

                    <asp:Button
                        ID="btnEliminarUsuario"
                        runat="server"
                        Text="Eliminar usuario"
                        CssClass="btn-eco"
                        OnClick="btnEliminarUsuario_Click"
                        CausesValidation="false" />

                </div>

            </section>


            <!-- LISTA DE USUARIOS -->

            <section class="eco-registros">

                <h2>Usuarios registrados</h2>

                <asp:GridView
                    ID="gvUsuarios"
                    runat="server"
                    AutoGenerateColumns="False"
                    CssClass="tabla-reciclaje"
                    EmptyDataText="No existen usuarios registrados.">

                    <Columns>

                        <asp:BoundField
                            DataField="id"
                            HeaderText="ID" />

                        <asp:BoundField
                            DataField="cedula"
                            HeaderText="Cédula" />

                        <asp:BoundField
                            DataField="nombre"
                            HeaderText="Nombre" />

                        <asp:BoundField
                            DataField="correo"
                            HeaderText="Correo" />

                    </Columns>

                </asp:GridView>

            </section>


            <!-- REGISTRAR RECICLAJE -->

            <section class="eco-form">

                <h2>♻️ Registrar reciclaje</h2>

                <div class="form-group">

                    <label for="ddlUsuario">
                        Usuario
                    </label>

                    <asp:DropDownList
                        ID="ddlUsuario"
                        runat="server"
                        CssClass="form-control">
                    </asp:DropDownList>

                    <asp:RequiredFieldValidator
                        ID="valUsuario"
                        runat="server"
                        ControlToValidate="ddlUsuario"
                        InitialValue="0"
                        ErrorMessage="Seleccione un usuario."
                        CssClass="mensaje-error"
                        Display="Dynamic"
                        ValidationGroup="Reciclaje">
                    </asp:RequiredFieldValidator>

                </div>


                <div class="form-group">

                    <label for="ddlMaterial">
                        Material reciclado
                    </label>

                    <asp:DropDownList
                        ID="ddlMaterial"
                        runat="server"
                        CssClass="form-control">
                    </asp:DropDownList>

                    <asp:RequiredFieldValidator
                        ID="valMaterial"
                        runat="server"
                        ControlToValidate="ddlMaterial"
                        InitialValue="0"
                        ErrorMessage="Seleccione un material."
                        CssClass="mensaje-error"
                        Display="Dynamic"
                        ValidationGroup="Reciclaje">
                    </asp:RequiredFieldValidator>

                </div>


                <div class="form-group">

                    <label for="txtCantidad">
                        Cantidad reciclada (kg)
                    </label>

                    <asp:TextBox
                        ID="txtCantidad"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Ejemplo: 2,50">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator
                        ID="valCantidad"
                        runat="server"
                        ControlToValidate="txtCantidad"
                        ErrorMessage="Ingrese una cantidad."
                        CssClass="mensaje-error"
                        Display="Dynamic"
                        ValidationGroup="Reciclaje">
                    </asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator
                        ID="valFormatoCantidad"
                        runat="server"
                        ControlToValidate="txtCantidad"
                        ValidationExpression="^\d+([,]\d{1,2})?$"
                        ErrorMessage="Ingrese una cantidad válida. Ejemplo: 2,50"
                        CssClass="mensaje-error"
                        Display="Dynamic"
                        ValidationGroup="Reciclaje">
                    </asp:RegularExpressionValidator>

                </div>


                <div class="form-group">

                    <label for="txtFecha">
                        Fecha
                    </label>

                    <asp:TextBox
                        ID="txtFecha"
                        runat="server"
                        CssClass="form-control"
                        TextMode="Date">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator
                        ID="valFecha"
                        runat="server"
                        ControlToValidate="txtFecha"
                        ErrorMessage="Seleccione una fecha."
                        CssClass="mensaje-error"
                        Display="Dynamic"
                        ValidationGroup="Reciclaje">
                    </asp:RequiredFieldValidator>

                </div>


                <asp:Button
                    ID="btnRegistrar"
                    runat="server"
                    Text="Registrar reciclaje"
                    CssClass="btn-eco"
                    OnClick="btnRegistrar_Click"
                    ValidationGroup="Reciclaje" />

            </section>


            <!-- REGISTROS DE RECICLAJE -->

            <section class="eco-registros">

                <h2>Registros de reciclaje</h2>

                <asp:GridView
                    ID="gvReciclajes"
                    runat="server"
                    AutoGenerateColumns="False"
                    CssClass="tabla-reciclaje"
                    EmptyDataText="No existen registros de reciclaje.">

                    <Columns>

                        <asp:BoundField
                            DataField="nombreUsuario"
                            HeaderText="Usuario" />

                        <asp:BoundField
                            DataField="nombreTipo"
                            HeaderText="Material" />

                        <asp:BoundField
                            DataField="cantidad"
                            HeaderText="Cantidad (kg)"
                            DataFormatString="{0:N2}" />

                        <asp:BoundField
                            DataField="fecha"
                            HeaderText="Fecha"
                            DataFormatString="{0:dd/MM/yyyy}" />

                    </Columns>

                </asp:GridView>

            </section>


            <!-- ESTADÍSTICAS -->

            <section class="eco-estadistica">

                <h2>Estadísticas de reciclaje</h2>

                <asp:GridView
                    ID="gvEstadistica"
                    runat="server"
                    AutoGenerateColumns="False"
                    CssClass="tabla-reciclaje"
                    EmptyDataText="No existen datos para mostrar.">

                    <Columns>

                        <asp:BoundField
                            DataField="MATERIAL"
                            HeaderText="Material" />

                        <asp:BoundField
                            DataField="TOTAL_KG"
                            HeaderText="Total reciclado (kg)"
                            DataFormatString="{0:N2}" />

                    </Columns>

                </asp:GridView>

            </section>

        </main>

    </form>

</body>

</html>

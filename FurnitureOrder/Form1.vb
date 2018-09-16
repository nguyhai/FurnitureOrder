' Two types of furniture, chairs and sofa
' Price of chair is $350, price of sofa is 925, sales tax is 5%
' Write program that creates an invoice for an order. Display using process order button (calculate everything with a function)
' Clear form button clears the form (put this in a function)
' Quit button exits the form
' The invoice number consists of the capitalized first two letters of the customers last name, followed by the last four digits of the zip code. 
' Make a method to create the invoice number
' The name displayed on the invoice is the proper order (first name, last name)

Public Class frmFurnitureOrder
    ' Create constants for the prices
    Dim ChairPrice As Double = 350.0
    Dim SofaPrice As Double = 925
    Dim SalesTax As Double = 0.05

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        ' Define variables
        Dim numOfChairs As Integer
        Dim numOfSofas As Integer

        Dim totalCost As Double
        Dim totalTax As Double
        Dim orderPrice As Double

        Dim name As String = txtName.Text
        Dim reverseName As String
        Dim address As String = txtAddress.Text
        Dim cityStateZip As String = txtCity.Text
        Dim invoiceNumber As String

        ' Get inputs and assign values to variables
        If ValidateInput(name, address, cityStateZip) Then
            numOfChairs = CInt(txtChairs.Text)
            numOfSofas = CInt(txtSofas.Text)

            ' Run functions to process the invoice number and invoice total cost, then another function to reverse the input of the name
            totalCost = CalculateTotalInvoice(numOfChairs, numOfSofas, totalTax, orderPrice)
            invoiceNumber = CreateInvoiceNumber(name, cityStateZip)
            reverseName = ReorderName(name)
        End If

        ' Display the order 

    End Sub

    ' Methods
    Private Function ValidateInput(name As String, street As String, cityStateZip As String) As Boolean
        If Not name.Contains(", ") Or name.Length < 4 Then
            MessageBox.Show("Invalid name, make sure names are separated by a comma.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf street = "" Or cityStateZip = "" Then
            MessageBox.Show("Invalid stree, city, state, or zip", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf Not IsNumeric(txtChairs.Text) Or Not IsNumeric(txtSofas.Text) Then
            MessageBox.Show("Invalid input for chairs or sofas", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtAddress.Clear()
        txtChairs.Clear()
        txtCity.Clear()
        txtName.Clear()
        txtSofas.Clear()
    End Sub

    Function CreateInvoiceNumber(name As String, cityStateZip As String) As String
        ' The invoice number consists of the capitalized first two letters of the customers last name, followed by the last four digits of the zip code. 
        ' We will need to parse out the last name and get the first 2 letters, then the last 4 digits of zip. use substrings

        Dim zipDigits As String
        Dim lettersName As String
        zipDigits = cityStateZip.Substring(cityStateZip.Length - 4) ' Last 4 digits
        lettersName = name.Substring(0, 2).ToUpper

        Return lettersName + zipDigits
    End Function

    Function CalculateTotalInvoice(chairs As Integer, sofas As Integer, ByRef totalTax As Double, ByRef orderPrice As Double) As Double
        ' Passing in total Tax and orderPrice as by reference, so this way it changes the values at their location
        orderPrice = (chairs * ChairPrice) + (sofas * SofaPrice)
        totalTax = orderPrice * SalesTax

        Return orderPrice + totalTax
    End Function


    Function ReorderName(name As String) As String
        Dim firstName As String
        Dim lastName As String
        Dim commaPosition As Integer

        ' Get the comma position
        commaPosition = name.IndexOf(",")

        firstName = name.Substring(commaPosition + 2) ' This makes it so that it will pull everything 2 spaces after the comma, which is the first name that we had
        lastName = name.Substring(0, commaPosition)

        Return firstName + ", " + lastName
    End Function

    Private Sub DisplayInvoice()

    End Sub

End Class

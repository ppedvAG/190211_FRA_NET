Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class CalcTests

    <TestMethod()>
    Public Sub Calc_Sum_3_and_4_Results_7()
        'Arrange    
        Dim calc As New Calc()

        'Action               
        Dim result = calc.Sum(3, 4)

        'Assert                    
        Assert.AreEqual(7, result)
    End Sub

    <TestMethod()>
    Public Sub Calc_Sum_0_and_0_Results_0()
        'Arrange    
        Dim calc As New Calc()
        'Calc calc = new Calc();
        'var calc = new Calc();

        'Action               
        Dim result = calc.Sum(0, 0)

        'Assert                    
        Assert.AreEqual(0, result)
    End Sub

    <TestMethod()>
    Public Sub Calc_Sum_MAX_and_1_Results______()

        Dim calc As New Calc()

        Assert.ThrowsException(Of OverflowException)(Sub() calc.Sum(Integer.MaxValue, 1))
        'Assert.ThrowsException<OverflowException>(() => calc.Sum(Integer.MaxValue, 1)); C#

    End Sub

    <TestMethod()>
    Public Sub Calc_Minus_3_and_4_Results_M1()
        'Arrange    
        Dim calc As New Calc()

        'Action               
        Dim result = calc.Minus(3, 4)

        'Assert                    
        Assert.AreEqual(-1, result)
    End Sub

    <TestMethod()>
    Public Sub Calc_IsWeekend()

        Dim calc As New Calc()

        Assert.IsFalse(calc.IsWeekend(New Date(2019, 2, 11)))
        Assert.IsTrue(calc.IsWeekend(New Date(2019, 2, 10)))

    End Sub
End Class
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Uppgift4_Josefin;

namespace InputTest
{
    [TestClass]
    class ParanthesesCheck
    {
        [TestMethod]
        public void TryUnevenInput_ReturnsUnbalanced()
        {
            //Arrange 
            //expected = unbalanced?


            //Act
            //input="())"

            //actual = message

            //Assert
            //areequal expected , actual 

        }
        // test on:
        //balanced
        // (())
        //([])
        //not balanced
        //([)4
        //[])
        //())   
        //}}
        //])[]
        //([]))
        //[(])
    }
}

namespace FStest.SomeDomainTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open DomainEntity
open FsCheck

[<TestClass>]
type DomainEntityTests () =

    [<TestMethod>]
    member _this.SayHello_PassViktorReturnsExpected () =
        let extected = "Hello, Viktor"

        let result = sayHello "Viktor"

        Assert.AreEqual(extected, result);
        
    [<TestMethod>]
    member _this.``pass 3 returns list of 3 elements`` () =      

        let result = getList 3

        Assert.AreEqual(3, (List.length result));

[<TestClass>]
type ``when join two lists`` () =
    [<TestMethod>]
    member _this.``length of result equls to sum of inpul lists length`` () =
        let a = [1;2]
        let b = [4;5;6]

        let joinListLenght l1 l2 = 
            (joinLists l1 l2).Length = (l1.Length + l2.Length)

        Check.Quick joinListLenght

module Queries

    type Customer = {State: string; ZipCode: string}
    
    //pipeline
    let customerZipCodesByState customers state =
        customers 
        |> Seq.filter (fun customer -> customer.State = state)
        |> Seq.map (fun customer -> customer.ZipCode)
        |> Seq.distinct
    //query 
    let customerZipCodeByStateQuery customers state =
        query {
            for customer in customers do
            where (customer.State = state)
            select customer.ZipCode
            distinct
        }
    
    //query expressions 
    open System.Diagnostics

    let activeProcCount = 
        query{
            for activeProcess in Process.GetProcesses() do
                count
        }

    let memoryHog =
        query {
            for activeProcess in Process.GetProcesses() do
                sortByDescending activeProcess.WorkingSet64
                head
        }

    //query operators
    //printProcessList windowedProcesses
    let windowedProcesses =
        query {
            for activeProcess in Process.GetProcesses() do 
            where (activeProcess.MainWindowHandle <> nativeint 0)
            select activeProcess
        }

    let printProcessList procSeq =
        Seq.iter (printfn "%A") procSeq

    //contains
    let isChromeRunnint = 
        query {
            for process in windowedProcesses do
            select process.ProcessName
            contains "chrome"
        }

    //count
    let numOfServiceProcesses = 
        query {
            for activeProcess in Process.GetProcesses() do
            where (activeProcess.MainWindowHandle <> nativeint 0)
            select activeProcess
            count
        }

    //maxBy 
    let highestThreadCount = 
        query{
            for process in Process.GetProcesses() do
            maxBy process.Threads.Count
        }

    //sorting 
    let sortedProcs = 
        query {
            for proc in Process.GetProcesses() do
            let isWindowed = proc.MainWindowHandle <> nativeint 0
            sortBy isWindowed
            thenBy proc.ProcessName
            select proc
            }
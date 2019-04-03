namespace RulesChain

module RulesChain =

    type TransactionType =
    | Add
    | Change
    | Remove

    type GovernBy =
    | Government
    | Organisation
    | Person

    type Rule  = NotImplemented

    type Transaction =
        val txType : TransactionType
        
        new (transactionType) = {
            txType = transactionType
        }
        
        member this.Type = this.txType
        

    let kek = Transaction(Add)
    
    let hello name =
        printfn "Hello %s" name

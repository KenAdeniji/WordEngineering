#include <ctime>
#include <iomanip>
#include <iostream>
#include <windows.h>
#include <sqltypes.h>
#include <sql.h>
#include <sqlext.h>
#include <vector>

#include "HisWord.hpp"

using namespace std;

/*
	http://www.codeproject.com/Questions/341111/How-to-connect-SQL-Server-to-Cplus-Program
	cl "YouHaveDisguisedTheGod.cpp" odbc32.lib
*/

void show_error(unsigned int handletype, const SQLHANDLE& handle){
    SQLCHAR sqlstate[1024];
    SQLCHAR message[1024];
    if(SQL_SUCCESS == SQLGetDiagRec(handletype, handle, 1, sqlstate, NULL, message, 1024, NULL))
        cout<<"Message: "<<message<<"\nSQLSTATE: "<<sqlstate<<endl;
}

void sqlProcess()
{
    SQLHANDLE sqlenvhandle;    
    SQLHANDLE sqlconnectionhandle;
    SQLHANDLE sqlstatementhandle;
    SQLRETURN retcode;

    if(SQL_SUCCESS!=SQLAllocHandle(SQL_HANDLE_ENV, SQL_NULL_HANDLE, &sqlenvhandle))
        goto FINISHED;

    if(SQL_SUCCESS!=SQLSetEnvAttr(sqlenvhandle,SQL_ATTR_ODBC_VERSION, (SQLPOINTER)SQL_OV_ODBC3, 0)) 
        goto FINISHED;
    
    if(SQL_SUCCESS!=SQLAllocHandle(SQL_HANDLE_DBC, sqlenvhandle, &sqlconnectionhandle))
        goto FINISHED;

    SQLCHAR retconstring[1024];
    switch(SQLDriverConnect (sqlconnectionhandle, 
                NULL, 
                (SQLCHAR*)"DRIVER={SQL Server};SERVER=localhost;DATABASE=WordEngineering;Integrated Security=SSPI", 
                SQL_NTS, 
                retconstring, 
                1024, 
                NULL,
                SQL_DRIVER_NOPROMPT)){
        case SQL_SUCCESS_WITH_INFO:
            show_error(SQL_HANDLE_DBC, sqlconnectionhandle);
            break;
        case SQL_INVALID_HANDLE:
        case SQL_ERROR:
            show_error(SQL_HANDLE_DBC, sqlconnectionhandle);
            goto FINISHED;
        default:
            break;
    }
    
    if(SQL_SUCCESS!=SQLAllocHandle(SQL_HANDLE_STMT, sqlconnectionhandle, &sqlstatementhandle))
        goto FINISHED;

    if(SQL_SUCCESS!=SQLExecDirect(sqlstatementhandle, (SQLCHAR*)"select top 5 SequenceOrderID, Word from HisWord ORDER BY SequenceOrderID DESC", SQL_NTS)){
        show_error(SQL_HANDLE_STMT, sqlstatementhandle);
        goto FINISHED;
    }
    else{
        char Word[2000];
        int id;
		
		vector<HisWord> hisWords;
	
        while(SQLFetch(sqlstatementhandle)==SQL_SUCCESS){
            SQLGetData(sqlstatementhandle, 1, SQL_C_ULONG, &id, 0, NULL);
            SQLGetData(sqlstatementhandle, 2, SQL_C_CHAR, Word, 2000, NULL);
            cout << id << " " << Word << endl;
			
			std::time_t t =  std::time(NULL);
			
			/*
			std::tm tm    = *std::localtime(&t);
			std::cout << "Time right now is " << std::put_time(&tm, "%c %Z") << '\n';
			*/
			
			HisWord *hisWord = new HisWord
			(
				id,
				t,
				Word	
			);

			hisWords.push_back(*hisWord);
        }
		
		for (int i = 0; i < hisWords.size(); ++i)
		{
			char *Word = hisWords[i].getWord();
			cout << hisWords[i].getSequenceOrderID() << "  " << Word << endl;
			//free(Word); 
			//delete[] Word;
		}	
    }

FINISHED:
    SQLFreeHandle(SQL_HANDLE_STMT, sqlstatementhandle );
    SQLDisconnect(sqlconnectionhandle);
    SQLFreeHandle(SQL_HANDLE_DBC, sqlconnectionhandle);
    SQLFreeHandle(SQL_HANDLE_ENV, sqlenvhandle);
    
}

int main(){
	sqlProcess();
}

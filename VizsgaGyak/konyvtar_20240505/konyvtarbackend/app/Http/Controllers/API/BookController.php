<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use App\Http\Requests\StoreBookRequest;
use App\Models\Book;
use App\Models\Rental;
use Illuminate\Http\Request;

use function PHPUnit\Framework\isEmpty;

class BookController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $books = Book::all();
        return response()->json(['data'=> $books]);
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(StoreBookRequest $request)
    {
        $book =  new Book($request->all());
        $book->save();
        return response()->json($book,201);
        
    }
    
    public function rent($id){
        $book = Book::find($id);
        if (is_null($book)) {
            return response()->json(["message"=> "Nem található könyv ezzel az azonosítóval: {$id}"],404);
        }
        $rentals = Rental::where([
            ["book_id", $id],
            ["start_date","<=",date("Y-m-d")],
            ["end_date",">",date("Y-m-d")]
        ])->get();

        if (!$rentals->isEmpty()) {
            return response()->json(["message"=>"A könyv jelenleg nem elérhető!"],409);
        }

        $rent = new Rental([
            "book_id" => $id,
            "start_date" => date("Y-m-d"),
            "end_date" => date("Y-m-d",strtotime('+1week'))
        ]);

        $rent->save();
        return response()->json($rent,201);
    }
    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        //
    }
}

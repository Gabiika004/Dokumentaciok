<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use App\Http\Requests\StoreCarRequest;
use App\Models\Car;
use App\Models\Rental;
use Illuminate\Http\Request;

class CarController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $cars = Car::all();
        return response()->json(['data'=> $cars]);
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(StoreCarRequest $request)
    {
        $car = new Car($request->all());
        $car->save();
        return response()->json($car,201);
    }

    /**
     * Rent a specified car for a week.
     */
    public function rent($id){

        $car = Car::find($id);
            if (is_null($car)) {
                return response()->json(['message'=> 'Nem található autó ilyen azonosítóval!'],404);
            }

        $rentals = Rental::where([
            ["car_id", $id],
            ["start_date", "<=", date("Y-m-d")],
            ["end_date",">=", date("Y-m-d")],
        ])->get();

        if (!$rentals->isEmpty()) {
            return response()->json(['message'=> "Az autó jelenleg nem elérhető!"],409);
        }

        $rental = new Rental([
            "car_id" => $id,
            "start_date" => date("Y-m-d"),
            "end_date" => date("Y-m-d", strtotime("+1 week"))
        ]);

        $rental->save();

        return response()->json($rental,201);
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

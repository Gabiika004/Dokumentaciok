<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use App\Http\Requests\StoreMemberRequest;
use App\Models\Member;
use App\Models\Payment;
use Carbon\Carbon;
use GuzzleHttp\Promise\Create;
use Illuminate\Http\Request;
use PHPUnit\Framework\Constraint\IsEmpty;

class MemberController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $members = Member::all();
        return response()->json(["data" => $members]);
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(StoreMemberRequest $request)
    {
        $item = new Member($request->all());
        $item-> save();
        return response()->json($item, 201);
    }

    public function pay(string $id)
    {
        $member = Member::find($id);
        if (is_null($member)) {
            return response()->json(["message" => "Member was not found with id: $id"], 404);
        }
        $startOfMonth = Carbon::now()->startOfMonth();

        $paymentAlreadyMade = Payment::where('member_id', $id)
            ->where('paid_at', '>=', $startOfMonth)
            ->where('amount', '>', 0)
            ->exists();
    
        if ($paymentAlreadyMade) {
            return response()->json(["message" => "This member has already paid this month's bill"], 409);
        }
    
        $paymentRecord = new Payment([
            "paid_at" => now(),
            "amount" => 5000,
            "member_id" => $id
        ]);
    
        $paymentRecord->save();
        return response()->json($paymentRecord);
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

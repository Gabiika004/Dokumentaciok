<?php

use App\Http\Controllers\API\MemberController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::apiResource("/members", MemberController::class);
Route::post("/members/{member}/pay",[MemberController::class, "pay"]);

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LabPlus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    account_status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    permission_level = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_admins", x => x.id);
                    table.ForeignKey(
                        name: "fk_admins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: true),
                    gender = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    reminders_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    package_status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    next_test_due_date = table.Column<DateOnly>(type: "date", nullable: true),
                    follow_up_date = table.Column<DateOnly>(type: "date", nullable: true),
                    follow_up_note = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_patients", x => x.id);
                    table.ForeignKey(
                        name: "fk_patients_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    specialty = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    license_no = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    license_doc_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    consultation_fee = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    rejection_reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    avg_rating = table.Column<decimal>(type: "numeric(3,2)", precision: 3, scale: 2, nullable: false),
                    clinic_address = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    latitude = table.Column<double>(type: "double precision", nullable: true),
                    longitude = table.Column<double>(type: "double precision", nullable: true),
                    approved_by_admin_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_doctors", x => x.id);
                    table.ForeignKey(
                        name: "fk_doctors_admins_approved_by_admin_id",
                        column: x => x.approved_by_admin_id,
                        principalTable: "admins",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_doctors_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "labs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    lab_type = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    address = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    latitude = table.Column<double>(type: "double precision", nullable: true),
                    longitude = table.Column<double>(type: "double precision", nullable: true),
                    license_no = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    license_doc_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    rejection_reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    approved_by_admin_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_labs", x => x.id);
                    table.ForeignKey(
                        name: "fk_labs_admins_approved_by_admin_id",
                        column: x => x.approved_by_admin_id,
                        principalTable: "admins",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_labs_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    notif_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    subject = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    body = table.Column<string>(type: "text", nullable: false),
                    channel = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    is_read = table.Column<bool>(type: "boolean", nullable: false),
                    sent_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    sent_by_admin_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notifications", x => x.id);
                    table.ForeignKey(
                        name: "fk_notifications_admins_sent_by_admin_id",
                        column: x => x.sent_by_admin_id,
                        principalTable: "admins",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_notifications_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chatbot_interactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    patient_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_question = table.Column<string>(type: "text", nullable: false),
                    bot_answer = table.Column<string>(type: "text", nullable: false),
                    input_type = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    disclaimer_shown = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    reported_incorrect = table.Column<bool>(type: "boolean", nullable: false),
                    report_reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    review_status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    reviewed_by_admin_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chatbot_interactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_chatbot_interactions_admins_reviewed_by_admin_id",
                        column: x => x.reviewed_by_admin_id,
                        principalTable: "admins",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_chatbot_interactions_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    patient_id = table.Column<Guid>(type: "uuid", nullable: false),
                    appointment_type = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    doctor_id = table.Column<Guid>(type: "uuid", nullable: true),
                    lab_id = table.Column<Guid>(type: "uuid", nullable: true),
                    consultation_type = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    scheduled_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    proposed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    reject_reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    cancel_reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    expires_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    disclaimer_accepted = table.Column<bool>(type: "boolean", nullable: false),
                    session_status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    session_link = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    medical_notes = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    recommended_tests = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    rating = table.Column<int>(type: "integer", nullable: true),
                    feedback = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    package_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appointments", x => x.id);
                    table.CheckConstraint("ck_appointment_rating", "rating IS NULL OR (rating BETWEEN 1 AND 5)");
                    table.CheckConstraint("ck_appointment_target", "(doctor_id IS NOT NULL AND lab_id IS NULL) OR (doctor_id IS NULL AND lab_id IS NOT NULL)");
                    table.ForeignKey(
                        name: "fk_appointments_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_appointments_labs_lab_id",
                        column: x => x.lab_id,
                        principalTable: "labs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_appointments_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "medical_reports",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    patient_id = table.Column<Guid>(type: "uuid", nullable: false),
                    lab_id = table.Column<Guid>(type: "uuid", nullable: true),
                    file_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    file_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    upload_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ocr_confidence = table.Column<double>(type: "double precision", nullable: true),
                    analysis_result = table.Column<string>(type: "jsonb", nullable: true),
                    is_kidney_related = table.Column<bool>(type: "boolean", nullable: false),
                    has_critical_value = table.Column<bool>(type: "boolean", nullable: false),
                    patient_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    reported_incorrect = table.Column<bool>(type: "boolean", nullable: false),
                    report_reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    review_status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    reviewed_by_admin_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medical_reports", x => x.id);
                    table.ForeignKey(
                        name: "fk_medical_reports_admins_reviewed_by_admin_id",
                        column: x => x.reviewed_by_admin_id,
                        principalTable: "admins",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_medical_reports_labs_lab_id",
                        column: x => x.lab_id,
                        principalTable: "labs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_medical_reports_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "patient_documents",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    patient_id = table.Column<Guid>(type: "uuid", nullable: false),
                    doc_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    file_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ai_assessment = table.Column<string>(type: "text", nullable: true),
                    basic_guidance = table.Column<string>(type: "text", nullable: true),
                    consult_recommendation = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    uploaded_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_shared = table.Column<bool>(type: "boolean", nullable: false),
                    shared_appointment_id = table.Column<Guid>(type: "uuid", nullable: true),
                    reported_incorrect = table.Column<bool>(type: "boolean", nullable: false),
                    report_reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    review_status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    reviewed_by_admin_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_patient_documents", x => x.id);
                    table.ForeignKey(
                        name: "fk_patient_documents_admins_reviewed_by_admin_id",
                        column: x => x.reviewed_by_admin_id,
                        principalTable: "admins",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_patient_documents_appointments_shared_appointment_id",
                        column: x => x.shared_appointment_id,
                        principalTable: "appointments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_patient_documents_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    appointment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    attempt_no = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    platform_share = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    gateway_ref = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    refund_reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    refund_decision = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    decided_by_admin_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payments", x => x.id);
                    table.ForeignKey(
                        name: "fk_payments_admins_decided_by_admin_id",
                        column: x => x.decided_by_admin_id,
                        principalTable: "admins",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_payments_appointments_appointment_id",
                        column: x => x.appointment_id,
                        principalTable: "appointments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "test_values",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    report_id = table.Column<Guid>(type: "uuid", nullable: false),
                    test_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    value = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    ref_range = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    unit = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    is_abnormal = table.Column<bool>(type: "boolean", nullable: false),
                    is_confirmed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_test_values", x => x.id);
                    table.ForeignKey(
                        name: "fk_test_values_medical_reports_report_id",
                        column: x => x.report_id,
                        principalTable: "medical_reports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_admins_user_id",
                table: "admins",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_appointments_doctor_id_scheduled_at",
                table: "appointments",
                columns: new[] { "doctor_id", "scheduled_at" },
                unique: true,
                filter: "doctor_id IS NOT NULL AND status IN ('Pending','Confirmed')");

            migrationBuilder.CreateIndex(
                name: "ix_appointments_expires_at",
                table: "appointments",
                column: "expires_at");

            migrationBuilder.CreateIndex(
                name: "ix_appointments_lab_id",
                table: "appointments",
                column: "lab_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointments_patient_id_status",
                table: "appointments",
                columns: new[] { "patient_id", "status" });

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_role_claims_role_id",
                table: "AspNetRoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claims_user_id",
                table: "AspNetUserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                table: "AspNetUserLogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_roles_role_id",
                table: "AspNetUserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_chatbot_interactions_patient_id_created_at",
                table: "chatbot_interactions",
                columns: new[] { "patient_id", "created_at" });

            migrationBuilder.CreateIndex(
                name: "ix_chatbot_interactions_reviewed_by_admin_id",
                table: "chatbot_interactions",
                column: "reviewed_by_admin_id");

            migrationBuilder.CreateIndex(
                name: "ix_doctors_approved_by_admin_id",
                table: "doctors",
                column: "approved_by_admin_id");

            migrationBuilder.CreateIndex(
                name: "ix_doctors_license_no",
                table: "doctors",
                column: "license_no",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_doctors_specialty",
                table: "doctors",
                column: "specialty");

            migrationBuilder.CreateIndex(
                name: "ix_doctors_user_id",
                table: "doctors",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_labs_approved_by_admin_id",
                table: "labs",
                column: "approved_by_admin_id");

            migrationBuilder.CreateIndex(
                name: "ix_labs_license_no",
                table: "labs",
                column: "license_no",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_labs_user_id",
                table: "labs",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_medical_reports_lab_id",
                table: "medical_reports",
                column: "lab_id");

            migrationBuilder.CreateIndex(
                name: "ix_medical_reports_patient_id_upload_date",
                table: "medical_reports",
                columns: new[] { "patient_id", "upload_date" });

            migrationBuilder.CreateIndex(
                name: "ix_medical_reports_reviewed_by_admin_id",
                table: "medical_reports",
                column: "reviewed_by_admin_id");

            migrationBuilder.CreateIndex(
                name: "ix_notifications_sent_by_admin_id",
                table: "notifications",
                column: "sent_by_admin_id");

            migrationBuilder.CreateIndex(
                name: "ix_notifications_user_id_is_read",
                table: "notifications",
                columns: new[] { "user_id", "is_read" });

            migrationBuilder.CreateIndex(
                name: "ix_patient_documents_patient_id_uploaded_at",
                table: "patient_documents",
                columns: new[] { "patient_id", "uploaded_at" });

            migrationBuilder.CreateIndex(
                name: "ix_patient_documents_reviewed_by_admin_id",
                table: "patient_documents",
                column: "reviewed_by_admin_id");

            migrationBuilder.CreateIndex(
                name: "ix_patient_documents_shared_appointment_id",
                table: "patient_documents",
                column: "shared_appointment_id");

            migrationBuilder.CreateIndex(
                name: "ix_patients_user_id",
                table: "patients",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_payments_appointment_id_attempt_no",
                table: "payments",
                columns: new[] { "appointment_id", "attempt_no" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_payments_decided_by_admin_id",
                table: "payments",
                column: "decided_by_admin_id");

            migrationBuilder.CreateIndex(
                name: "ix_payments_gateway_ref",
                table: "payments",
                column: "gateway_ref");

            migrationBuilder.CreateIndex(
                name: "ix_test_values_report_id_test_name",
                table: "test_values",
                columns: new[] { "report_id", "test_name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "chatbot_interactions");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "patient_documents");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "test_values");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "medical_reports");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "labs");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
